using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class Location
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public string City { get; set; }

        public string Type { get; set; }
    }
}