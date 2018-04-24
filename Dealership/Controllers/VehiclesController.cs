using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Dealership.Models;

namespace Dealership.Controllers
{
    [Authorize] //Used to allow access to views related to a particular controller only when logged
    public class VehiclesController : Controller
    {
        private UsedVehicleDealership db = new UsedVehicleDealership();

        // GET: Vehicles
        [OverrideAuthorization]
        public ActionResult Index()
        {
            var vehicles = db.Vehicles.Include(v => v.Make).Include(v => v.Model);
            //ViewBag.BookCount = vehicles.Count(); // .Count() property stores the number of cars found by the search
                                                    // and saves it in the ViewBag

            return View(db.Vehicles.OrderBy(v => v.soldDate).ToList()); // Cars ordered by sold date
        }

        // POST: VehiclesController/Index
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(String Make)
        {
            var vehicles = from b in db.Makes select b;

            if (Make != "") //If the search box is not empty...
            {
                vehicles = vehicles.Where(v => v.make1.Contains(Make)); //return books that matches the search query
            }

            ViewBag.BookCount = vehicles.Count();
            return View(vehicles);
        }

        // GET: Vehicles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // GET: Vehicles/Create
        public ActionResult Create()
        {
            ViewBag.makeID = new SelectList(db.Makes, "makeID", "make1");
            ViewBag.modelID = new SelectList(db.Models, "modelID", "colour");
            return View();
        }

        // POST: Vehicles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleID,makeID,modelID,year,price,cost,soldDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Vehicles.Add(vehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.makeID = new SelectList(db.Makes, "makeID", "make1", vehicle.makeID);
            ViewBag.modelID = new SelectList(db.Models, "modelID", "colour", vehicle.modelID);
            return View(vehicle);
        }

        // GET: Vehicles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.makeID = new SelectList(db.Makes, "makeID", "make1", vehicle.makeID);
            ViewBag.modelID = new SelectList(db.Models, "modelID", "colour", vehicle.modelID);
            return View(vehicle);
        }

        // POST: Vehicles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleID,makeID,modelID,year,price,cost,soldDate")] Vehicle vehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.makeID = new SelectList(db.Makes, "makeID", "make1", vehicle.makeID);
            ViewBag.modelID = new SelectList(db.Models, "modelID", "colour", vehicle.modelID);
            return View(vehicle);
        }

        // GET: Vehicles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vehicle vehicle = db.Vehicles.Find(id);
            if (vehicle == null)
            {
                return HttpNotFound();
            }
            return View(vehicle);
        }

        // POST: Vehicles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vehicle vehicle = db.Vehicles.Find(id);
            db.Vehicles.Remove(vehicle);
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
