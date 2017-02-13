using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;

namespace Violin.Store.Web.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
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