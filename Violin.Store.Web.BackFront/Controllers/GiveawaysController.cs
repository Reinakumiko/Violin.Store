using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;
using Violin.Store.Tools.Filters;
using Violin.Store.Classes.AccessFlags;

namespace Violin.Store.Web.BackFront.Controllers
{
	[LoginRequired]
	[AccessRequired(UserAccess.Store, UserAccess.Admin)]
	public class GiveawaysController : Controller
	{
		private DatabaseContext db = new DatabaseContext();

		// GET: Giveaways
		public async Task<ActionResult> Index()
		{
			return View(await db.Giveaways.ToListAsync());
		}

		// GET: Giveaways/Details/5
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Giveaway giveaway = await db.Giveaways.FindAsync(id);
			if (giveaway == null)
			{
				return HttpNotFound();
			}
			return View(giveaway);
		}

		// GET: Giveaways/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Giveaways/Create
		// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
		// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "GivewayId,Name")] Giveaway giveaway)
		{
			if (ModelState.IsValid)
			{
				db.Giveaways.Add(giveaway);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			return View(giveaway);
		}

		// GET: Giveaways/Edit/5
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Giveaway giveaway = await db.Giveaways.FindAsync(id);
			if (giveaway == null)
			{
				return HttpNotFound();
			}
			return View(giveaway);
		}

		// POST: Giveaways/Edit/5
		// 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
		// 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> Edit([Bind(Include = "GivewayId,Name")] Giveaway giveaway)
		{
			if (ModelState.IsValid)
			{
				db.Entry(giveaway).State = EntityState.Modified;
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}
			return View(giveaway);
		}

		// GET: Giveaways/Delete/5
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Giveaway giveaway = await db.Giveaways.FindAsync(id);
			if (giveaway == null)
			{
				return HttpNotFound();
			}
			return View(giveaway);
		}

		// POST: Giveaways/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult> DeleteConfirmed(int id)
		{
			Giveaway giveaway = await db.Giveaways.FindAsync(id);
			db.Giveaways.Remove(giveaway);
			await db.SaveChangesAsync();
			return RedirectToAction("Index");
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
