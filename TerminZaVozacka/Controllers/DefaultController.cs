using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TerminZaVozacka.Models;

namespace TerminZaVozacka.Controllers
{
    public class DefaultController: Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ApplicationDbContext entities = new ApplicationDbContext();
            return View(entities.FileModels.ToList());
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase postedFile)
        {
            byte[] bytes;
            using (BinaryReader br = new BinaryReader(postedFile.InputStream))
            {
                bytes = br.ReadBytes(postedFile.ContentLength);
            }
            ApplicationDbContext entities = new ApplicationDbContext();
            entities.FileModels.Add(new FileModel
            {
                Name = Path.GetFileName(postedFile.FileName),
                ContentType = postedFile.ContentType,
                Data = bytes
            });
            entities.SaveChanges();
            return RedirectToAction("Index", "Default");
        }
    }
}