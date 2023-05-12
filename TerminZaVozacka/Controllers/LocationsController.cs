using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TerminZaVozacka.Models;
using EntityState = System.Data.Entity.EntityState;

namespace TerminZaVozacka.Controllers
{
    public class LocationsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Locations
        public ActionResult Index()
        {
            LocationDropDownModel model = new LocationDropDownModel()
            {
                Locations = db.Locations,
            Cities = new List<string>() {"All" ,"Skopje", "Bitola", "Gostivar" },
            Types = new List<string>() {"All" ,"Apply", "Starting Position" }
        };
            return View(model);
        }

        [HttpPost]
        public ActionResult SelectLocation(LocationDropDownModel model)
        {
            IEnumerable<Location> locations = null;

            if (model.SelectedCity.Equals("All") && model.SelectedType.Equals("All"))
            {
                locations = db.Locations;
            }else if (model.SelectedCity.Equals("All"))
            {
                locations = db.Locations.Where(m => m.Type == model.SelectedType).ToList();
            } else if (model.SelectedType.Equals("All"))
            {
                locations = db.Locations.Where(m => m.City == model.SelectedCity).ToList();
            }
            else
            {
                locations = db.Locations.Where(m => m.City == model.SelectedCity)
                    .Where(m => m.Type == model.SelectedType).ToList();
            }

            model.Locations = locations;
            model.Cities = new List<string>() { "All", "Skopje", "Bitola", "Gostivar" };
            model.Types = new List<string>() { "All", "Apply", "Starting Position" };

            return View("Index", model);
        }


        // GET: Locations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Locations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Link")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Locations.Add(location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(location);
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Link")] Location location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(location);
        }

        // GET: Locations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Location location = db.Locations.Find(id);
            if (location == null)
            {
                return HttpNotFound();
            }
            return View(location);
        }

        // POST: Locations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Location location = db.Locations.Find(id);
            db.Locations.Remove(location);
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
