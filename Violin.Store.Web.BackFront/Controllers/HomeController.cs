using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Classes.AccessFlags;
using Violin.Store.Database;
using Violin.Store.Tools;
using Violin.Store.Tools.Filters;

namespace Violin.Store.Web.BackFront.Controllers
{
	public class HomeController : Controller
	{
		private DatabaseContext _database = new DatabaseContext();

		// GET: Home
		[LoginRequired(IsBackstage = true)]
		[AccessRequired(UserAccess.Admin, UserAccess.News, UserAccess.Store)]
		public ActionResult Index()
        {
            return View();
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

			if (throwResult.Result)
			{
				this.Session["user"] = dbUser;
			}

			return this.RequestResult(throwResult);
		}

		public ActionResult InvalidPermission()
		{
			return View();
		}
	}
}