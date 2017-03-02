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
    public class DiscographiesController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Discographies
        public ActionResult Index()
        {
            return View(db.Discography.ToList());
        }

        // GET: Discographies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discography discography = db.Discography.Find(id);
            if (discography == null)
            {
                return HttpNotFound();
            }
            return View(discography);
        }

        // GET: Discographies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Discographies/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DiscographyId,CoverImage,Title,Subtitle,Description,OnSaleTime,ProductNumber,Price")] Discography discography)
        {
            if (ModelState.IsValid)
            {
                db.Discography.Add(discography);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(discography);
        }

        // GET: Discographies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discography discography = db.Discography.Find(id);
            if (discography == null)
            {
                return HttpNotFound();
            }
            return View(discography);
        }

        // POST: Discographies/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DiscographyId,CoverImage,Title,Subtitle,Description,OnSaleTime,ProductNumber,Price")] Discography discography)
        {
            if (ModelState.IsValid)
            {
                db.Entry(discography).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(discography);
        }

        // GET: Discographies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Discography discography = db.Discography.Find(id);
            if (discography == null)
            {
                return HttpNotFound();
            }
            return View(discography);
        }

        // POST: Discographies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Discography discography = db.Discography.Find(id);
            db.Discography.Remove(discography);
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
