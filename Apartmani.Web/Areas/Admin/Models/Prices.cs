using Apartmani.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Areas.Admin.Models
{
    public class Prices
    {
        [Key]
        public int Id { get; set; }

        public int Year { get; set; }

        [ForeignKey(nameof(Apartment))]
        public int ApartmentID { get; set; }
        public virtual Apartment Apartment { get; set; }

        public int January { get; set; }
        public int Fabruary { get; set; }
        public int March { get; set; }
        public int April { get; set; }
        public int May { get; set; }
        public int June { get; set; }
        public int July { get; set; }
        public int August { get; set; }
        public int Septembar { get; set; }
        public int Octobar { get; set; }
        public int Novembar { get; set; }
        public int Decembar { get; set; }

        public virtual int[] Months { get; set; }

        public Prices()
        {
            Months = new int[12];
        }
    }
}