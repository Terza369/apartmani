using Apartmani.Web.Areas.Admin.Models.Calendar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apartmani.Web.Areas.Admin.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Admin/Calendar
        public ActionResult Index(int? month, int? year, int? apartment)
        {
            if(!month.HasValue)
            {
                month = DateTime.Now.Month;
            }

            if(!year.HasValue)
            {
                year = DateTime.Now.Year;
            }

            if(!apartment.HasValue)
            {
                apartment = 2;
            }

            if(month == 0)
            {
                month = 12;
                year--;
            }

            if (month == 13)
            {
                month = 1;
                year++;
            }

            return PartialView("_Calendar", new Month(month.Value, year.Value, apartment.Value));
        }
    }
}