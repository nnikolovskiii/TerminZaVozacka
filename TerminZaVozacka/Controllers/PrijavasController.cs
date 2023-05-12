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
using Microsoft.VisualBasic;
using System.IO;
using TerminZaVozacka.Migrations;
using TeorijaPrijava = TerminZaVozacka.Models.TeorijaPrijava;
using DateTime = System.DateTime;

namespace TerminZaVozacka.Controllers
{
    [Authorize(Roles = "User")]
    public class PrijavasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        

        // GET: Prijavas
        public ActionResult Index()
        {
            var data = from prijava in db.Prijavas
                       where prijava.UserName == User.Identity.Name
                       where prijava.IsAccepted == false
                       select prijava;
            return View("Index",data.ToList());
        }

        public ActionResult Accepted()
        {
            var data = from prijava in db.Prijavas
                       where prijava.UserName == User.Identity.Name
                       where prijava.IsAccepted == true
                       select prijava;
            return View(db.Prijavas.ToList());
        }

        // GET: Prijavas/Details/5
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

    
        

        public ActionResult CreateExam()
        {
            PrijavaTypeModel model = new PrijavaTypeModel();
           
            return View(model);
        }


        // POST: Prijavas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateExam(PrijavaTypeModel model)
        {
       
            FileModel f = SaveImage(model.LicnaKarta);
            FileModel f1 = SaveImage(model.Uplatnica);
            teorijaPrijava.LicnaKartaId = model.Prijava.LicnaKartaId;
            teorijaPrijava.Uplatnica = model.Prijava.Uplatnica;
         

            return this.CheckExam(teorijaPrijava);
        }

        public ActionResult CheckExam(TeorijaPrijava model)
        {
            if (ModelState.IsValid)
            {
                db.Prijavas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return null ;
        }

        // GET: Prijavas/Edit/5
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

        // POST: Prijavas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Prijava prijava)
        {
            Prijava find = db.Prijavas.Find(prijava.Id);
            if (find != null)
            {
                find.Name = prijava.Name;
                find.Surname = prijava.Surname;
                find.IdentificationNumber = prijava.IdentificationNumber;
                db.Entry(find).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(prijava);
        }

        // GET: Prijavas/Delete/5
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

        // POST: Prijavas/Delete/5
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


        public FileModel SaveImage(HttpPostedFileBase httpPosted)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(httpPosted.InputStream))
            {
                bytes = br.ReadBytes(httpPosted.ContentLength);
            }
            ApplicationDbContext entities = new ApplicationDbContext();
            FileModel fileModel = entities.FileModels.Add(new FileModel
            {
                Name = Path.GetFileName(httpPosted.FileName),
                ContentType = httpPosted.ContentType,
                Data = bytes
            });
            entities.SaveChanges();

            return fileModel;
        }
// GET: Prijavas/Create
        public ActionResult Create()
        {
            PrijavaTypeModel model = new PrijavaTypeModel();
            model.Types = new List<string>() {
                "A1", "A2", "AM", "B","B17","F","G"
                ,"A", "A1", "BE", "C","CE", "C1", "C1E", "D", "DE","D1","D1E"
            };
            return View(model);
        }
        
        public ActionResult Valid(PrijavaTypeModel model)
        {
            if (ModelState.IsValid)
            {
                return this.SelectType(model);
            }
            
            return View("Create", model);
        }

        public ActionResult SelectType(PrijavaTypeModel model)
        {

            FileModel Licna = SaveImage(model.LicnaKarta);
            FileModel Uplatnica = SaveImage(model.Uplatnica);
            FileModel Obrazovanie = SaveImage(model.Obrazovanie);
            FileModel Zdravstveno = SaveImage(model.Zdravstveno);
            FileModel Potvrda = SaveImage(model.PotvrdaZaCasovi);

            string[] bezPrethodna = new string[]
            {
                "A1", "A2", "AM", "B","B17","F","G"
            };

            string[] soPrethodna = new string[]
            {
                "A", "A1", "BE", "C","CE", "C1", "C1E", "D", "DE","D1","D1E"
            };

            var type = model.SelectedItem;
            if (bezPrethodna.Contains(type) ) {
                BTypePrijava d = new BTypePrijava();
                d.Id = model.Prijava.Id;
                d.UserName = model.Prijava.UserName;
                d.IdentificationNumber = model.Prijava.IdentificationNumber;
                d.IsAccepted = model.Prijava.IsAccepted;
                d.Name = model.Prijava.Name;
                d.Surname = model.Prijava.Surname;
                d.Category = model.Prijava.Category ;
                d.Type = type;
                d.LicnaKartaId = Licna.Id;
                d.Uplatnica = Uplatnica.Id;
                d.Obrazovanie = Obrazovanie.Id;
                d.Zdravstveno = Zdravstveno.Id;
                d.PotvrdaZaCasovi = Potvrda.Id;            
                d.DateTime = DateTime.Now;
                d.Time = new TimeSpan();
                d.CreationTime = DateTime.Now;
                return RedirectToAction("CheckSelectTypeB", d);
            }
            if (soPrethodna.Contains(type))
            {
                ATypePrijava d = new ATypePrijava();
                d.Id = model.Prijava.Id;
                d.UserName = model.Prijava.UserName;
                d.IdentificationNumber = model.Prijava.IdentificationNumber;
                d.IsAccepted = model.Prijava.IsAccepted;
                d.Name = model.Prijava.Name;
                d.Surname = model.Prijava.Surname;
                d.Category = model.Prijava.Category;
                d.Type = type;
                d.LicnaKartaId = Licna.Id;
                d.Uplatnica = Uplatnica.Id;
                d.Obrazovanie = Obrazovanie.Id;
                d.Zdravstveno = Zdravstveno.Id;
                d.PotvrdaZaCasovi = Potvrda.Id;
                d.DateTime = DateTime.Now;
                d.Time = new TimeSpan();
                d.CreationTime = DateTime.Now;
                return PartialView("ATypeSelect", d);
            }

            return null;
        }

        

        
        public ActionResult CheckSelectTypeB(BTypePrijava model)

        {
            if (ModelState.IsValid)
            {
                db.Prijavas.Add(model);
                db.SaveChanges();
                return PartialView("Success");
            }
            PrijavaTypeModel d = new PrijavaTypeModel() 
            {
                Prijava = new Prijava(),
                Types = new List<string>() { "B", "A", "Employee" }
            };
            d.Prijava.Id = model.Id;
            d.Prijava.UserName = model.UserName;
            d.Prijava.IdentificationNumber = model.IdentificationNumber;
            d.Prijava.IsAccepted = model.IsAccepted;
            d.Prijava.Category = "B";
            d.Prijava.Name = model.Name;
            d.Prijava.Surname = model.Surname;
            return View("Create", d);
        }

        public ActionResult CheckSelectTypeA(ATypePrijava model, HttpPostedFileBase PrethodnaVozacka)

        {
            FileModel fileModel = SaveImage(PrethodnaVozacka);
            model.PrethodnaVozackaId = fileModel.Id;
            if (ModelState.IsValid)
            {
                db.Prijavas.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return null;
        }
    }
}



