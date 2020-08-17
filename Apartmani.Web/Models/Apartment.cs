using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Models
{
    public class Apartment
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public int Bedrooms { get; set; }
        public int Beds { get; set; }
        public int AdditionalBeds { get; set; }

        public virtual ICollection<Visitor> Visitors { get; set; }
    }
}