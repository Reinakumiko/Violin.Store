using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;

namespace Violin.Store.Web.Controllers
{
    public class HomeController : Controller
    {
		DatabaseContext database = new DatabaseContext();

        // GET: Home
        public ActionResult Index()
        {
			ViewBag.News = database.News.OrderByDescending(news => news.ReleaseTime).Take(5).ToList();

            return View();
        }

		public ActionResult News(int? newsid)
		{
			if (!newsid.HasValue)
				return RedirectToAction("Index");

			return View();
		}
    }
}