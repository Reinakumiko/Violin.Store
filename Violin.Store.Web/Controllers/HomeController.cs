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
			//获得最新前五条的新闻内容
            ViewBag.News = database.News.OrderByDescending(news => news.ReleaseTime).Take(5).ToList();

			//获得最新电视日程前五条的内容
			ViewBag.ScheduleTV = database.Schedule
										 .Where(schedule => schedule.Type == ScheduleType.TV)
										 .OrderByDescending(schedule => schedule.StartTime)
										 .Take(5)
										 .ToList();

			//获得最新广播日程的前五条内容
			ViewBag.ScheduleRadio = database.Schedule
											.Where(schedule => schedule.Type == ScheduleType.Radio)
											.OrderByDescending(schedule => schedule.ScheduleId)
											.Take(5)
											.ToList();

			return View();
        }
    }
}