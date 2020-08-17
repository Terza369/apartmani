using Apartmani.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Areas.Admin.Models
{
    public class Status
    {
        public VisitorGroup Group { get; set; }
        public int Price { get; set; }
        public bool Arrival { get; set; }
        public bool Departure { get; set; }
        public bool Future { get; set; }

        public Status(VisitorGroup group)
        {
            this.Group = group;
        }
    }
}