using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class LocationDropDownModel
    {
        public IEnumerable<Location> Locations { get; set; }
        public ICollection<string> Cities { get; set; }
        public string SelectedCity{ get; set; }

        public string SelectedType { get; set; }

        public ICollection<string> Types { get; set; }
    }
}