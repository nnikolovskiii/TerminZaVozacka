﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TerminZaVozacka.Models
{
    public class CategorySideBarModel
    {
        public IEnumerable<Category> Categories { get; set; }
        public CategoryReqModel Category { get; set; }
    }
}