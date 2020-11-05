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
    [Authorize]
    public class SharePackagesController : Controller
    {
        private CommunityGardenEntities db = new CommunityGardenEntities();

        // GET: SharePackages
        public ActionResult Index()
        {
            var sharePackages = db.SharePackages.Include(s => s.Neighbor).Include(s => s.Shareable).Include(s => s.ShareEvent);
            return View(sharePackages.ToList());
        }

        // GET: SharePackages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharePackage sharePackage = db.SharePackages.Find(id);
            if (sharePackage == null)
            {
                return HttpNotFound();
            }
            return View(sharePackage);
        }

        // GET: SharePackages/Create
        public ActionResult Create()
        {
            ViewBag.NeighborID = new SelectList(db.Neighbors, "NeighborID", "FirstName");
            ViewBag.ShareableID = new SelectList(db.Shareables, "ShareableID", "ShareableName");
            ViewBag.ShareEventID = new SelectList(db.ShareEvents, "ShareEventID", "ShareEventID");
            return View();
        }

        // POST: SharePackages/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SharePackageID,ShareableID,Quantity,ShareEventID,NeighborID,IsActive")] SharePackage sharePackage)
        {
            if (ModelState.IsValid)
            {
                db.SharePackages.Add(sharePackage);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NeighborID = new SelectList(db.Neighbors, "NeighborID", "FirstName", sharePackage.NeighborID);
            ViewBag.ShareableID = new SelectList(db.Shareables, "ShareableID", "ShareableName", sharePackage.ShareableID);
            ViewBag.ShareEventID = new SelectList(db.ShareEvents, "ShareEventID", "ShareEventID", sharePackage.ShareEventID);
            return View(sharePackage);
        }

        // GET: SharePackages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharePackage sharePackage = db.SharePackages.Find(id);
            if (sharePackage == null)
            {
                return HttpNotFound();
            }
            ViewBag.NeighborID = new SelectList(db.Neighbors, "NeighborID", "FirstName", sharePackage.NeighborID);
            ViewBag.ShareableID = new SelectList(db.Shareables, "ShareableID", "ShareableName", sharePackage.ShareableID);
            ViewBag.ShareEventID = new SelectList(db.ShareEvents, "ShareEventID", "ShareEventID", sharePackage.ShareEventID);
            return View(sharePackage);
        }

        // POST: SharePackages/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SharePackageID,ShareableID,Quantity,ShareEventID,NeighborID,IsActive")] SharePackage sharePackage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sharePackage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NeighborID = new SelectList(db.Neighbors, "NeighborID", "FirstName", sharePackage.NeighborID);
            ViewBag.ShareableID = new SelectList(db.Shareables, "ShareableID", "ShareableName", sharePackage.ShareableID);
            ViewBag.ShareEventID = new SelectList(db.ShareEvents, "ShareEventID", "ShareEventID", sharePackage.ShareEventID);
            return View(sharePackage);
        }

        // GET: SharePackages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SharePackage sharePackage = db.SharePackages.Find(id);
            if (sharePackage == null)
            {
                return HttpNotFound();
            }
            return View(sharePackage);
        }

        // POST: SharePackages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SharePackage sharePackage = db.SharePackages.Find(id);
            db.SharePackages.Remove(sharePackage);
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
