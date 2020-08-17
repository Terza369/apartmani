using Apartmani.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Areas.Admin.Models.Calendar
{
    public class Month
    {
        public int Id { get; set; }
        public int Year { get; set; }
        public int StartingDayOfWeek { get; set; }
        public List<Day> Days { get; set; }
        public int ApartmentID { get; set; }

        private VisitorsManagerDbContext db = new VisitorsManagerDbContext();

        public Month(int month, int year, int apartmentId)
        {
            this.Id = month;
            this.Year = year;
            this.ApartmentID = apartmentId;
            this.StartingDayOfWeek = (int)new DateTime(year, month, 1).DayOfWeek;

            this.Days = new List<Day>();

            for(int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                this.Days.Add(SetDay(new DateTime(year, month, i)));
            }
        }

        public Day SetDay(DateTime datum)
        {
            var day = new Day();

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateTo > datum) && (p.DateFrom < datum)))
            {
                day.Occupied = true;
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateFrom.Equals(datum))))
            {
                day.Arrival = true;
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateTo.Equals(datum))))
            {
                day.Departure = true;
            }

            return day;
        }
    }
}