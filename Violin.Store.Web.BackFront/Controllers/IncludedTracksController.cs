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
    public class IncludedTracksController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: IncludedTracks
        public ActionResult Index()
        {
            var includedTracks = db.IncludedTracks.Include(i => i.Discography);
            return View(includedTracks.ToList());
        }

        // GET: IncludedTracks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncludedTracks includedTracks = db.IncludedTracks.Include(i => i.Discography).Where(i => i.Track == id).FirstOrDefault();
			if (includedTracks == null)
            {
                return HttpNotFound();
            }
            return View(includedTracks);
        }

        // GET: IncludedTracks/Create
        public ActionResult Create()
        {
            ViewBag.DiscographyId = new SelectList(db.Discography, "DiscographyId", "Title");
            return View();
        }

        // POST: IncludedTracks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Track,Name,LyricsBy,Composer,Arranger,DiscographyId")] IncludedTracks includedTracks)
        {
            if (ModelState.IsValid)
            {
                db.IncludedTracks.Add(includedTracks);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DiscographyId = new SelectList(db.Discography, "DiscographyId", "Title", includedTracks.DiscographyId);
            return View(includedTracks);
        }

        // GET: IncludedTracks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncludedTracks includedTracks = db.IncludedTracks.Find(id);
            if (includedTracks == null)
            {
                return HttpNotFound();
            }
            ViewBag.DiscographyId = new SelectList(db.Discography, "DiscographyId", "Title", includedTracks.DiscographyId);
            return View(includedTracks);
        }

        // POST: IncludedTracks/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Track,Name,LyricsBy,Composer,Arranger,DiscographyId")] IncludedTracks includedTracks)
        {
            if (ModelState.IsValid)
            {
                db.Entry(includedTracks).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DiscographyId = new SelectList(db.Discography, "DiscographyId", "Title", includedTracks.DiscographyId);
            return View(includedTracks);
        }

        // GET: IncludedTracks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IncludedTracks includedTracks = db.IncludedTracks.Find(id);
            if (includedTracks == null)
            {
                return HttpNotFound();
            }
            return View(includedTracks);
        }

        // POST: IncludedTracks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IncludedTracks includedTracks = db.IncludedTracks.Find(id);
            db.IncludedTracks.Remove(includedTracks);
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
