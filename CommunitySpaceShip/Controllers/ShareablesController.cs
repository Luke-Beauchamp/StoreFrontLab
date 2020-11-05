using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CommunitySpaceShipData;

namespace CommunitySpaceShip.Controllers
{
    [Authorize(Roles = "Admin,Coordinator")]
    public class ShareablesController : Controller
    {
        private CommunityGardenEntities db = new CommunityGardenEntities();

        // GET: Shareables
        public ActionResult Index()
        {
            var shareables = db.Shareables.Include(s => s.Category);
            return View(shareables.ToList());
        }

        // GET: Shareables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shareable shareable = db.Shareables.Find(id);
            if (shareable == null)
            {
                return HttpNotFound();
            }
            return View(shareable);
        }

        // GET: Shareables/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName");
            return View();
        }

        // POST: Shareables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShareableID,ShareableName,CategoryID")] Shareable shareable)
        {
            if (ModelState.IsValid)
            {
                db.Shareables.Add(shareable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", shareable.CategoryID);
            return View(shareable);
        }

        // GET: Shareables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shareable shareable = db.Shareables.Find(id);
            if (shareable == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", shareable.CategoryID);
            return View(shareable);
        }

        // POST: Shareables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShareableID,ShareableName,CategoryID")] Shareable shareable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shareable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "CategoryID", "CategoryName", shareable.CategoryID);
            return View(shareable);
        }

        // GET: Shareables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Shareable shareable = db.Shareables.Find(id);
            if (shareable == null)
            {
                return HttpNotFound();
            }
            return View(shareable);
        }

        // POST: Shareables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Shareable shareable = db.Shareables.Find(id);
            db.Shareables.Remove(shareable);
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
