using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class ATypePrijava : Prijava
    {
 

        [Required]
        public int PrethodnaVozackaId { get; set; }
    }
}