using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class CategoryReqModel
    {
        public Category Category { get; set; }
        public string[] Req { get; set; }
    }
}