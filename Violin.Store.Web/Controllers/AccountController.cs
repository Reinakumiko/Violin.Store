using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
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
    public class AccountController : Controller
    {

        DatabaseContext _database = new DatabaseContext();

        // GET: Account
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserAccount user)
        {
            var accSet = _database.Account;

            //检测账号是否已存在于数据库
            if (accSet.CheckRepeat(acc => acc.Account == user.Account))
            {
                //提示错误消息
                return this.RequestResult(new ViewThrow() { StatusCode = HttpStatusCode.Forbidden, Message = "当前账户已存在。" });
            }

            //为用户设置加密密码
            SetUserPassowrd(user);

            //将注册的账号添加到表缓存中
            accSet.Add(user);

            //将表缓存写入到数据库表，且返回结果与提示消息。
            var throwResult = _database.SaveChanges() > 0
                            ? new ViewThrow() { StatusCode = HttpStatusCode.OK, Result = true, Message = "账号注册成功。" }
                            : new ViewThrow() { StatusCode = HttpStatusCode.InternalServerError, Message = "注册用户处理出错，请稍后再试。" };

            //
            return this.RequestResult(throwResult);
        }

        public ActionResult Login()
        {
			if (Session["user"] != null && Session["user"] is UserAccount)
				return RedirectToAction("Orders", "Store");

            return View();
        }

        [HttpPost]
        public ActionResult Login(UserAccount user)
        {
            var dbUser = _database.Account.Where(u => u.Account == user.Account).FirstOrDefault();
            user.Salt = dbUser?.Salt;

            var throwResult = user == dbUser
                            ? new ViewThrow() { StatusCode = HttpStatusCode.OK, Result = true, Message = "用户登录。" }
                            : new ViewThrow() { StatusCode = HttpStatusCode.InternalServerError, Message = "用户或密码错误，请检查核对之后再试。" };
            
            if(throwResult.Result)
            {
                this.Session["user"] = dbUser;
            }

            return this.RequestResult(throwResult);
        }

		public void Logout()
		{
			Session["user"] = null;
		}

        public ActionResult PasswordReset()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PasswordReset(UserAccount user)
        {
            var dbUser = _database.Account.Where(u => u.Account == user.Account).FirstOrDefault();
            dbUser.Password = user.Password;
            SetUserPassowrd(dbUser);

            //将表缓存写入到数据库表，且返回结果与提示消息。
            var throwResult = _database.SaveChanges() > 0
                            ? new ViewThrow() { StatusCode = HttpStatusCode.OK, Result = true, Message = "账号密码重置成功。" }
                            : new ViewThrow() { StatusCode = HttpStatusCode.InternalServerError, Message = "密码重置处理出错，请稍后再试。" };

            //
            return this.RequestResult(throwResult);
        }


		public ActionResult InvalidPermission()
		{
			return View();
		}

		[LoginRequired]
		public ActionResult Address()
		{
			var user = Session["user"] as UserAccount;
			var addresses =_database.ReceveAddresses.Where(d => d.AccountId == user.UserId);

			return View(addresses);
		}

		[LoginRequired]
		public ActionResult NewAddress()
		{
			return View();
		}

		[HttpPost, LoginRequired, ValidateAntiForgeryToken]
		public ActionResult NewAddress([Bind(Include = "Consignee, Address, PhoneNumber, PostCode")] ReceveAddress receiveAddress)
		{
			if (ModelState.IsValid)
			{
				var user = Session["user"] as UserAccount;

				var dbUser = _database.Account.Find(user.UserId);

				receiveAddress.Account = dbUser;
				_database.ReceveAddresses.Add(receiveAddress);
				_database.SaveChanges();
				return RedirectToAction("Address");
			}

			return View(receiveAddress);
		}

		[LoginRequired]
		public ActionResult EditAddress(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ReceveAddress address = _database.ReceveAddresses.Find(id);
			if (address == null)
			{
				return HttpNotFound();
			}
			return View(address);
		}

		[HttpPost, LoginRequired]
		public ActionResult EditAddress(ReceveAddress address)
		{
			if (ModelState.IsValid)
			{
				_database.Entry(address).State = EntityState.Modified;
				_database.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(address);
		}

		[HttpPost, LoginRequired]
		public ActionResult DeleteAddress(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}

			var address = _database.ReceveAddresses.Find(id);
			_database.ReceveAddresses.Remove(address);

			var result = false;
			var message = string.Empty;

			try
			{
				result = _database.SaveChanges() > 0;
				message = result
						? "已成功将收货地址删除。"
						: "移除收货地址失败，稍后刷新再试。";
			}
			catch (DbException ex)
			{
				message = ex.Message;
			}

			return this.RequestResult(new ViewThrow() {
				Result = result,
				Message = message
			});
		}

		[HttpPost, LoginRequired]
		public ActionResult SetDefaultAddress(int id)
		{
			var address = _database.ReceveAddresses.Find(id);
			var addressList = _database.ReceveAddresses.Where(d => d.AccountId == address.AccountId && d.Default);

			addressList.ToList().ForEach(d => d.Default = false);
			address.Default = true;

			var result = false;
			var message = string.Empty;

			try
			{
				result = _database.SaveChanges() > 0;

				message = result
						? "成功将地址设置为默认地址。"
						: "设置默认地址时失败，请稍后再尝试。";
			}
			catch (DbException ex)
			{
				message = ex.Message;
			}
			
			return this.RequestResult(new ViewThrow() {
				Message = message,
				Result = result,
			});
		}

		private void SetUserPassowrd(UserAccount user)
        {
            user.Salt = user.GenerateSalt();
            user.Password = user.EncryptPassword();
        }
    }
}