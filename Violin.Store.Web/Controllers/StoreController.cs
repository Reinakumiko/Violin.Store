using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;
using Violin.Store.Tools;
using Violin.Store.Tools.Filters;

namespace Violin.Store.Web.Controllers
{
	public class StoreController : Controller
	{

		DatabaseContext database = new DatabaseContext();

		// GET: Store
		public ActionResult Index()
		{

			var productList = database.Goods.OrderByDescending(g => g.ProductId);

			return View(productList);
		}

		public ActionResult Detail(int? id)
		{
			if (!id.HasValue)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "this request is invalid");

			var productInfo = database.Goods.Find(id);

			if (productInfo == null)
				return HttpNotFound();

			return View(productInfo);
		}

		[LoginRequired]
		public ActionResult Checkout()
		{
			var user = Session["user"] as UserAccount;
			var shoppingCart = database.Cart.Where(r => r.Account.UserId == user.UserId).OrderByDescending(r => r.CartId);

			ViewBag.User = user;

			return View(shoppingCart.ToList());
		}

		[HttpPost, LoginRequired]
		public ActionResult Checkout(int id, int qty)
		{
			var user = Session["user"] as UserAccount;
			var dbUser = database.Account.Find(user.UserId);

			database.Cart.Add(new ShoppingCart()
			{
				Account = dbUser,
				Goods = database.Goods.Find(id),
				Quantity = qty
			});

			database.SaveChanges();

			return RedirectToAction("Checkout");
		}

		[LoginRequired]
		public ActionResult Orders()
		{
			return View();
		}

		// HttpPost 用于后台提交
		// LoginRequired 表示操作登陆后可执行
		// 未登录无法操作购物车
		[HttpPost, LoginRequired]
		public ActionResult RemoveFormCheckout(int id)
		{
			var message = string.Empty;
			var result = false;
			try
			{
				database.Cart.RemoveRange(database.Cart.Where(c => c.CartId == id));
				result = database.SaveChanges() > 0;

				message = result
						? "Checkout 记录已成功删除。"
						: "删除操作时失败，请稍后重新尝试删除该记录。";
			}
			catch (DbException ex)
			{
				message = ex.Message;
			}

			var throwResult = new ViewThrow()
			{
				StatusCode = HttpStatusCode.OK,
				Result = true,
				Message = message
			};

			return this.RequestResult(throwResult);
		}

		[HttpPost, LoginRequired]
		public ActionResult Payment(List<int> id)
		{
			if ((id?.Count ?? 0) < 1)
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Invalid request");

			var message = string.Empty;
			var result = false;

			var user = Session["user"] as UserAccount;
			var dbUser = database.Account.Find(user.UserId);
			var cartInfos = database.Cart.Where(cart => id.Contains(cart.CartId));
			var productPrices = cartInfos.Sum(cart => cart.Goods.Price * cart.Quantity);
			var address = database.ReceveAddresses.Where(addr => addr.AccountId == dbUser.UserId && addr.Default).FirstOrDefault();

			if (user.Cash < productPrices)
			{
				message = "结算失败，账户可用余额不足以支付当前商品价格。";
			}
			else
			{
				var timeStamp = DateTime.Now.ToString("yyyyMMddHHmmss");
				var hashCode = user.GetHashCode().ToString("X2").Substring(0, 2);

				//开启数据库事务
				using (var transcation = database.Database.BeginTransaction())
				{
					//生成订单
					database.Orders.Add(new Orders()
					{
						OrderNumber = $"OR15{timeStamp}{hashCode}",
						Goods = cartInfos.Select(cart => cart.Goods).ToList(),
						Account = dbUser,
						Address = address
					});

					//移除已提交的 Checkout 列表
					database.Cart.RemoveRange(cartInfos);

					//扣除账户上的积分
					dbUser.Cash -= productPrices;

					try
					{
						//储存到数据库
						if (database.SaveChanges() > 0)
						{
							result = true;
							message = "支付信息已提交，待审核通过后即可订单发货。";

							//提交事务
							transcation.Commit();
						}
						else
						{
							message = "提交支付信息时出错，请稍后再尝试提交。";

							//回滚事务
							transcation.Rollback();
						}
					}
					catch (DbException ex)
					{
						message = ex.Message;
					}
				}
			}

			return this.RequestResult(new ViewThrow()
			{
				Message = message,
				Result = result
			});
		}
	}
}