using Apartmani.Web.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apartmani.Web.Areas.Admin.Models
{
    public class Inquiry
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Field 'Arrival' is required.")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Field 'Departure' is required.")]
        public DateTime DateTo { get; set; }

        [ForeignKey(nameof(Apartment))]
        [Required(ErrorMessage = "Field 'Apartment' is required.")]
        public int ApartmentID { get; set; }
        public virtual Apartment Apartment { get; set; }

        [Required(ErrorMessage = "Field 'Persons' is required.")]
        [Range(1, 10)]
        public int Persons { get; set; }

        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field 'Last Name' is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field 'Email' is required.")]
        public string Email { get; set; }

        public string Phone { get; set; }
        public string Message { get; set; }

        public bool Accepted { get; set; }
        public bool Declined { get; set; }

        public bool Availability { get; set; }

        public void SetAvailabilitiy()
        {
            VisitorsManagerDbContext db = new VisitorsManagerDbContext();

            this.Availability = true;

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateTo > this.DateFrom) && (p.DateFrom < this.DateFrom)))
            {
                this.Availability = false;
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateFrom < this.DateTo) && (p.DateTo > this.DateTo)))
            {
                this.Availability = false;
            }

            if (db.VisitorGroups.Where(p => p.ApartmentID == this.ApartmentID).Any(p => (p.DateFrom > this.DateFrom) && (p.DateTo < this.DateTo)))
            {
                this.Availability = false;
            }
        }
    }
}