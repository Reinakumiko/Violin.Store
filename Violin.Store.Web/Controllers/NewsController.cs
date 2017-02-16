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
			News news = db.News.Find(id);
			if (news == null)
			{
				return HttpNotFound();
			}

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