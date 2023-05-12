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
    [Authorize(Roles = "Administrator")]
    public class AdminController : Controller
    {
        
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View(db.Prijavas.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,UserName,Type,Category,IdentificationNumber,IsAccepted")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Prijavas.Add(prijava);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(prijava);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Admin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,UserName,Type,Category,IdentificationNumber,IsAccepted")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prijava prijava = db.Prijavas.Find(id);
            if (prijava == null)
            {
                return HttpNotFound();
            }
            return View(prijava);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prijava prijava = db.Prijavas.Find(id);
            db.Prijavas.Remove(prijava);
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
