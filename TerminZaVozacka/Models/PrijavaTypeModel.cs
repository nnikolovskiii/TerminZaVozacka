using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class PrijavaTypeModel
    {
        public Prijava Prijava { get; set; }
        public ICollection<string> Types { get; set; }
        public string SelectedItem { get; set; }

        public HttpPostedFileBase LicnaKarta { get; set; }

        public HttpPostedFileBase Zdravstveno { get; set; }

        public HttpPostedFileBase Obrazovanie { get; set; }

        public HttpPostedFileBase PotvrdaZaCasovi { get; set; }

        public HttpPostedFileBase Uplatnica { get; set; }
    }
}