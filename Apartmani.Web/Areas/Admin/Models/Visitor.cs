using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Apartmani.Web.Models
{
    public class Visitor
    {
        [Key]
        public int Id { get; set; }

        public IdentificationType IdentificationType { get; set; }

        [Required(ErrorMessage = "Polje 'Broj isprave' je obvezno.")]
        public string IdentificationNumber { get; set; }

        [Required(ErrorMessage = "Polje 'Prezime' je obvezno.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Polje 'Ime' je obvezno.")]
        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        [Required(ErrorMessage = "Polje 'Spol' je obvezno.")]
        public Sex Sex { get; set; }

        [Required(ErrorMessage = "Polje 'Država prebivanja' je obvezno.")]
        [ForeignKey(nameof(ResidenceCountry))]
        public int ResidenceCountryID { get; set; }
        public virtual Country ResidenceCountry { get; set; }

        [Required(ErrorMessage = "Polje 'Grad prebivanja' je obvezno.")]
        [ForeignKey(nameof(ResidenceCity))]
        public int ResidenceCityID { get; set; }
        public virtual City ResidenceCity { get; set; }

        public string ResidenceAddress { get; set; }

        [Required(ErrorMessage = "Polje 'Država rođenja' je obvezno.")]
        [ForeignKey(nameof(BirthCountry))]
        public int BirthCountryID { get; set; }
        public virtual Country BirthCountry { get; set; }

        [Required(ErrorMessage = "Polje 'Grad rođenja' je obvezno.")]
        [ForeignKey(nameof(BirthCity))]
        public int BirthCityID { get; set; }
        public virtual City BirthCity { get; set; }

        [Required(ErrorMessage = "Polje 'Datum rođenja' je obvezno.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Polje 'Državljanstvo' je obvezno.")]
        [ForeignKey(nameof(Citizenship))]
        public int CitizenshipID { get; set; }
        public virtual Country Citizenship { get; set; }

        public TaxpayerCategory TaxpayerCategory { get; set; }
        public ArrivalOrganization ArrivalOrganization { get; set; }
        public TypeOfService TypeOfService { get; set; }

        [ForeignKey(nameof(VisitorGroup))]
        public int VisitorGroupID { get; set; }
        public virtual VisitorGroup VisitorGroup { get; set; }
    }

    public enum IdentificationType
    {
        Putovnica = 0,
        Osobna = 1
    }

    public enum Sex
    {
        Muški = 1,
        Ženski = 2
    }

    public enum TaxpayerCategory
    {
        bla1 = 0,
        bla2 = 1
    }

    public enum ArrivalOrganization
    {
        Osobno = 0,
        AgencjskiGrupno = 1,
        Agencijski60 = 2
    }

    public enum TypeOfService
    {
        Noćenje = 0,
        Prebivanje = 1
    }
}