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
    public class ParksController : Controller
    {
        private CommunityGardenEntities db = new CommunityGardenEntities();

        // GET: Parks
        public ActionResult Index()
        {
            var parks = db.Parks.Include(p => p.Region);
            return View(parks.ToList());
        }

        // GET: Parks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // GET: Parks/Create
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName");
            return View();
        }

        // POST: Parks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkID,RegionID,City,Address,State,ZipCode")] Park park)
        {
            if (ModelState.IsValid)
            {
                db.Parks.Add(park);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", park.RegionID);
            return View(park);
        }

        // GET: Parks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", park.RegionID);
            return View(park);
        }

        // POST: Parks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkID,RegionID,City,Address,State,ZipCode")] Park park)
        {
            if (ModelState.IsValid)
            {
                db.Entry(park).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", park.RegionID);
            return View(park);
        }

        // GET: Parks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Park park = db.Parks.Find(id);
            if (park == null)
            {
                return HttpNotFound();
            }
            return View(park);
        }

        // POST: Parks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Park park = db.Parks.Find(id);
            db.Parks.Remove(park);
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
