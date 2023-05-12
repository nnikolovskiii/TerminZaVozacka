using Org.BouncyCastle.Asn1.Mozilla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class PrijavaModel
    {
        public Prijava Prijava { get; set; }
        public FileModel FileModel { get; set; }
    }
}