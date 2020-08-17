using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Models
{
    public class VisitorGroup
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Polje 'Naziv' je obvezno.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Polje 'Datum dolaska' je obvezno.")]
        public DateTime DateFrom { get; set; }

        [Required(ErrorMessage = "Polje 'Datum odlaska' je obvezno.")]
        public DateTime DateTo { get; set; }
        public DateTime TimeOfCreation { get; set; }

        [ForeignKey(nameof(Apartment))]
        [Required(ErrorMessage = "Polje 'Apartman' je obvezno.")]
        public int ApartmentID { get; set; }
        public virtual Apartment Apartment { get; set; }

        public string BrojMobitela { get; set; }

        public string Email { get; set; }

        public int? BrojOsoba { get; set; }

        public bool Kolijevka { get; set; }

        public string Message { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }

        public VisitorGroup()
        {
            TimeOfCreation = DateTime.Now;
        }
    }
}