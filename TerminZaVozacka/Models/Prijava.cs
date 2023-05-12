using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class Prijava
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public String UserName { get; set; }
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string IdentificationNumber { get; set; }
        [Required]
        public Boolean IsAccepted { get; set; }
        [Required]

        public DateTime CreationTime { get; set; }
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public TimeSpan Time { get; set; }
        [Required]
        public int LicnaKartaId { get; set; }
        [Required]
        public int Zdravstveno { get; set; }
        [Required]
        public int Obrazovanie { get; set; }
        [Required]
        public int PotvrdaZaCasovi { get; set; }
        [Required]
        public int Uplatnica { get; set; }

    }
}