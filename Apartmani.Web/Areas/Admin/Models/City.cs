using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey(nameof(Country))]
        public int CountryID { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}