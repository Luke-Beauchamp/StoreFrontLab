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
    public class NeighborsController : Controller
    {
        private CommunityGardenEntities db = new CommunityGardenEntities();
        

        // GET: Neighbors
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var neighbors = db.Neighbors.Include(n => n.Region);
            return View(neighbors.ToList());
        }

        // GET: Neighbors/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbor neighbor = db.Neighbors.Find(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }
            return View(neighbor);
        }

        // GET: Neighbors/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName");
            return View();
        }

        // POST: Neighbors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "NeighborID,FirstName,LastName,Email,RegionID,ProduceAvailable,DairyAvailable,EggsAvailable")] Neighbor neighbor)
        {
            if (ModelState.IsValid)
            {
                db.Neighbors.Add(neighbor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", neighbor.RegionID);
            return View(neighbor);
        }

        [Authorize(Roles = "Intro")]
        public ActionResult CreateUser()
        {
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName");
            return View();
        }

        // POST: Neighbors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Intro")]
        public ActionResult CreateUser([Bind(Include = "NeighborID,FirstName,LastName,Email,RegionID,ProduceAvailable,DairyAvailable,EggsAvailable")] Neighbor neighbor)
        {

            if (ModelState.IsValid)
            {
                db.Neighbors.Add(neighbor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", neighbor.RegionID);
            return View(neighbor);
        }

        // GET: Neighbors/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbor neighbor = db.Neighbors.Find(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", neighbor.RegionID);
            return View(neighbor);
        }

        // POST: Neighbors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NeighborID,FirstName,LastName,Email,RegionID,ProduceAvailable,DairyAvailable,EggsAvailable")] Neighbor neighbor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(neighbor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RegionID = new SelectList(db.Regions, "RegionID", "RegionName", neighbor.RegionID);
            return View(neighbor);
        }

        // GET: Neighbors/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Neighbor neighbor = db.Neighbors.Find(id);
            if (neighbor == null)
            {
                return HttpNotFound();
            }
            return View(neighbor);
        }

        // POST: Neighbors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Neighbor neighbor = db.Neighbors.Find(id);
            db.Neighbors.Remove(neighbor);
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
