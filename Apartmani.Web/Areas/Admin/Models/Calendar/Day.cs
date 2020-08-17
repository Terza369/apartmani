using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Areas.Admin.Models.Calendar
{
    public class Day
    {
        public bool Occupied { get; set; }
        public bool Arrival { get; set; }
        public bool Departure { get; set; }
    }
}