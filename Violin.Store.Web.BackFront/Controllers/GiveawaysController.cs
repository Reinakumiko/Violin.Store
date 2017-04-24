using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Violin.Store.Classes;
using Violin.Store.Database;

namespace Violin.Store.Web.BackFront.Controllers
{
    public class GiveawaysController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Giveaways
        public ActionResult Index()
        {
            var giveaways = db.Giveaways.Include(g => g.Discography);
            return View(giveaways.ToList());
        }

        // GET: Giveaways/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giveaways giveaways = db.Giveaways.Find(id);
            if (giveaways == null)
            {
                return HttpNotFound();
            }
            return View(giveaways);
        }

        // GET: Giveaways/Create
        public ActionResult Create()
        {
            ViewBag._idDiscography = new SelectList(db.Discography, "DiscographyId", "Title");
            return View();
        }

        // POST: Giveaways/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GivewayId,Name,_idDiscography")] Giveaways giveaways)
        {
            if (ModelState.IsValid)
            {
                db.Giveaways.Add(giveaways);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag._idDiscography = new SelectList(db.Discography, "DiscographyId", "Title", giveaways._idDiscography);
            return View(giveaways);
        }

        // GET: Giveaways/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giveaways giveaways = db.Giveaways.Find(id);
            if (giveaways == null)
            {
                return HttpNotFound();
            }
            ViewBag._idDiscography = new SelectList(db.Discography, "DiscographyId", "Title", giveaways._idDiscography);
            return View(giveaways);
        }

        // POST: Giveaways/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GivewayId,Name,_idDiscography")] Giveaways giveaways)
        {
            if (ModelState.IsValid)
            {
                db.Entry(giveaways).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag._idDiscography = new SelectList(db.Discography, "DiscographyId", "Title", giveaways._idDiscography);
            return View(giveaways);
        }

        // GET: Giveaways/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Giveaways giveaways = db.Giveaways.Find(id);
            if (giveaways == null)
            {
                return HttpNotFound();
            }
            return View(giveaways);
        }

        // POST: Giveaways/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Giveaways giveaways = db.Giveaways.Find(id);
            db.Giveaways.Remove(giveaways);
            db.SaveChanges();
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
