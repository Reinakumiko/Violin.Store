﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;

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

		private ActionResult Checkout()
		{
			var user = Session["user"] as UserAccount;
			var shoppingCart = database.Cart.Where(r => r.Account.UserId == user.UserId).OrderByDescending(r => r.CartId);

			return View(shoppingCart);
		}

		public ActionResult Checkout(int? id, int? qty)
		{
			if (id != null && qty != null)
			{
				database.Cart.Add(new ShoppingCart()
				{
					Account = Session["user"] as UserAccount,
					Goods = database.Goods.Find(id),
					Quantity = qty.Value
				});
			}
			else if ((id ?? qty) != null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "无效的请求。");
			}

			return Checkout();
		}
	}
}