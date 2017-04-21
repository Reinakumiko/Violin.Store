using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;

namespace Violin.Store.Web.Controllers
{
    public class NewsController : Controller
	{
		DatabaseContext db = new DatabaseContext();

		// GET: News
		public ActionResult Index(int? id)
		{
			if (id.HasValue)
				return NewsDetail(id);

			ViewBag.News = db.News.OrderByDescending(news => news.ReleaseTime).Take(5).ToList();

			return View();
        }

		public ActionResult NewsDetail(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}


			var newsList = db.News.ToList();

			News news = newsList.Find(@new => @new.NewsID == id);
			if (news == null)
			{
				return HttpNotFound();
			}

			var index = newsList.IndexOf(news);

			ViewBag.Next = index < newsList.Count - 1
						 ? newsList[(index + 1)].NewsID.ToString()
						 : "#";

			ViewBag.Prev = index > 0
						 ? newsList[(index - 1)].NewsID.ToString()
						 : "#";

			return View("NewsDetail", news);
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				db.Dispose();
			}
			base.Dispose(disposing);
		}
	}
}