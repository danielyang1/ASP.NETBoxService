using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Crafty.Models;

namespace Crafty.Controllers
{
    public class BoxModelsController : Controller
    {
        private RegisteredUserDBContext db = new RegisteredUserDBContext();

        // GET: BoxModels
        public ActionResult Index()
        {
            return View(db.BoxModels.ToList());
        }

        // GET: BoxModels/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box boxModels = db.BoxModels.Find(id);
            if (boxModels == null)
            {
                return HttpNotFound();
            }
            return View(boxModels);
        }

        // GET: BoxModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BoxModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,boxName,boxPrice")] Box boxModels)
        {
            if (ModelState.IsValid)
            {
                db.BoxModels.Add(boxModels);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(boxModels);
        }

        // GET: BoxModels/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box boxModels = db.BoxModels.Find(id);
            if (boxModels == null)
            {
                return HttpNotFound();
            }
            return View(boxModels);
        }

        // POST: BoxModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,boxName,boxPrice")] Box boxModels)
        {
            if (ModelState.IsValid)
            {
                db.Entry(boxModels).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(boxModels);
        }

        // GET: BoxModels/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Box boxModels = db.BoxModels.Find(id);
            if (boxModels == null)
            {
                return HttpNotFound();
            }
            return View(boxModels);
        }

        // POST: BoxModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Box boxModels = db.BoxModels.Find(id);
            db.BoxModels.Remove(boxModels);
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
