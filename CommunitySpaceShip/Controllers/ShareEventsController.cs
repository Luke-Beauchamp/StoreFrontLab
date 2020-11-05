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
    public class ShareEventsController : Controller
    {
        private CommunityGardenEntities db = new CommunityGardenEntities();

        // GET: ShareEvents
        public ActionResult Index()
        {
            var shareEvents = db.ShareEvents.Include(s => s.Neighbor).Include(s => s.Park);
            return View(shareEvents.ToList());
        }

        // GET: ShareEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareEvent shareEvent = db.ShareEvents.Find(id);
            if (shareEvent == null)
            {
                return HttpNotFound();
            }
            return View(shareEvent);
        }

        // GET: ShareEvents/Create
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Create()
        {
            ViewBag.Coordinator = new SelectList(db.Neighbors, "NeighborID", "FirstName");
            ViewBag.ParkID = new SelectList(db.Parks, "ParkID", "City");
            return View();
        }

        // POST: ShareEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShareEventID,ParkID,Coordinator,Date,StartTime,EndTime")] ShareEvent shareEvent)
        {
            if (ModelState.IsValid)
            {
                db.ShareEvents.Add(shareEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Coordinator = new SelectList(db.Neighbors, "NeighborID", "FirstName", shareEvent.Coordinator);
            ViewBag.ParkID = new SelectList(db.Parks, "ParkID", "City", shareEvent.ParkID);
            return View(shareEvent);
        }

        // GET: ShareEvents/Edit/5
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareEvent shareEvent = db.ShareEvents.Find(id);
            if (shareEvent == null)
            {
                return HttpNotFound();
            }
            ViewBag.Coordinator = new SelectList(db.Neighbors, "NeighborID", "FirstName", shareEvent.Coordinator);
            ViewBag.ParkID = new SelectList(db.Parks, "ParkID", "City", shareEvent.ParkID);
            return View(shareEvent);
        }

        // POST: ShareEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShareEventID,ParkID,Coordinator,Date,StartTime,EndTime")] ShareEvent shareEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(shareEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Coordinator = new SelectList(db.Neighbors, "NeighborID", "FirstName", shareEvent.Coordinator);
            ViewBag.ParkID = new SelectList(db.Parks, "ParkID", "City", shareEvent.ParkID);
            return View(shareEvent);
        }

        // GET: ShareEvents/Delete/5
        [Authorize(Roles = "Admin,Coordinator")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShareEvent shareEvent = db.ShareEvents.Find(id);
            if (shareEvent == null)
            {
                return HttpNotFound();
            }
            return View(shareEvent);
        }

        // POST: ShareEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ShareEvent shareEvent = db.ShareEvents.Find(id);
            db.ShareEvents.Remove(shareEvent);
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
