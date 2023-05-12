using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using TerminZaVozacka.Models;
using EntityState = System.Data.Entity.EntityState;

namespace TerminZaVozacka.Controllers
{
    [Authorize(Roles = "Employee")]
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult NotAccepted()
        {
            var data = from prijava in db.Prijavas.ToList()
            where prijava.IsAccepted == false
            select prijava;
            return View("Accepted", data.ToList());  
        }

        // GET: Employee
        public ActionResult Accepted()
        {
            var data = from prijava in db.Prijavas.ToList()
                       where prijava.IsAccepted == true
                       select prijava;
            return View(data.ToList());
        }


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

        // POST: Prijavas1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Surname,UserName,Type,Category,IdentificationNumber,IsAccepted,DateTime,Time")] Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Employee/Details/5
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
            

            bool v = prijava is BTypePrijava;
            if (v)
            {
                return View("BDetails", prijava);
            }

            v = prijava is ATypePrijava;
            if (v)
            {
                return View("ADetails", prijava);
            }

            v = prijava is TeorijaPrijava;
            if (v)
            {
                return View("Details", prijava);
            }
           

            return View(prijava);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(Prijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Accepted");
            }
            return View(prijava);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult TeorijaDetails(TeorijaPrijava prijava)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prijava).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Accepted");
            }
            return View(prijava);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult RetrieveImage(int id)
        {
            byte[] cover = GetImageFromDataBase(id, GetDb());
            if (cover != null)
            {
                return File(cover, "image/jpg");
            }
            else
            {
                return null;
            }
        }

        public ApplicationDbContext GetDb()
        {
            return db;
        }

        public byte[] GetImageFromDataBase(int Id, ApplicationDbContext db)
        {
            byte[] cover = db.FileModels.First(m => m.Id == Id).Data ;
            return cover;
        }
    }
}
