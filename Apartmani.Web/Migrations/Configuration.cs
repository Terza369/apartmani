namespace Apartmani.Web.Migrations
{
    using Apartmani.Web.Models;
    using Apartmani.Web.Areas.Admin.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Apartmani.Web.Areas.Admin.Models.VisitorsManagerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Apartmani.Web.Areas.Admin.Models.VisitorsManagerDbContext context)
        {
            context.Apartments.AddOrUpdate(p => p.Id,
                new Apartment() { Id = 1, Name = "Mali", Size = 40, Bedrooms = 1, Beds = 2, AdditionalBeds = 1 },
                new Apartment() { Id = 2, Name = "Veliki", Size = 65, Bedrooms = 2, Beds = 4, AdditionalBeds = 2 }
                );

            context.VisitorGroups.AddOrUpdate(p => p.Id,
                new VisitorGroup() { Id = 1, Name = "Terzanoviæ", DateFrom = new DateTime(2018, 6, 24), DateTo = new DateTime(2018, 7, 1), ApartmentID = 2 },
                new VisitorGroup() {  Id = 2, Name = "Smith", DateFrom = new DateTime(2018, 8, 20), DateTo = new DateTime(2018, 8, 25), ApartmentID = 1 }
                );

            context.Visitors.AddOrUpdate(p => p.Id,
                                new Visitor()
                                {
                                    Id = 1,
                                    VisitorGroupID = 1,
                                    ArrivalOrganization = ArrivalOrganization.Osobno,
                                    BirthCityID = 1,
                                    BirthCountryID = 1,
                                    BirthDate = new DateTime(1991, 9, 27),
                                    CitizenshipID = 1,
                                    FirstName = "Šimun",
                                    IdentificationNumber = "321654351384354",
                                    IdentificationType = IdentificationType.Putovnica,
                                    LastName = "Terzanović",
                                    ResidenceAddress = "Zajčeva 7",
                                    ResidenceCityID = 1,
                                    ResidenceCountryID = 1,
                                    Sex = Sex.Muški,
                                    TaxpayerCategory = TaxpayerCategory.bla1,
                                    TypeOfService = TypeOfService.Noćenje
                                },
                                new Visitor()
                                {
                                    Id = 2,
                                    VisitorGroupID = 1,
                                    ArrivalOrganization = ArrivalOrganization.Osobno,
                                    BirthCityID = 1,
                                    BirthCountryID = 1,
                                    BirthDate = new DateTime(1998, 1, 1),
                                    CitizenshipID = 1,
                                    FirstName = "Mateja",
                                    IdentificationNumber = "6585656845684",
                                    IdentificationType = IdentificationType.Putovnica,
                                    LastName = "Terzanović",
                                    ResidenceAddress = "Zajčeva 7",
                                    ResidenceCityID = 1,
                                    ResidenceCountryID = 1,
                                    Sex = Sex.Ženski,
                                    TaxpayerCategory = TaxpayerCategory.bla1,
                                    TypeOfService = TypeOfService.Noćenje
                                }

                );

            context.Countries.AddOrUpdate(p => p.Id,
                new Country() { Id = 1, Name = "Croatia"},
                new Country() { Id = 2, Name = "Slovenia" },
                new Country() { Id = 3, Name = "Austria" },
                new Country() { Id = 4, Name = "Germany" },
                new Country() { Id = 5, Name = "Netherlands" },
                new Country() { Id = 6, Name = "Sweden" },
                new Country() { Id = 7, Name = "Denmark" },
                new Country() { Id = 8, Name = "France" },
                new Country() { Id = 9, Name = "Spain" },
                new Country() { Id = 10, Name = "Great Britain" }
                );

            context.Cities.AddOrUpdate(p => p.Id,
                new City() { Id = 1, Name = "Zagreb", CountryID = 1},
                new City() { Id = 2, Name = "Rijeka", CountryID = 1},
                new City() { Id = 3, Name = "Osijek", CountryID = 1},
                new City() { Id = 4, Name = "Ljubljana", CountryID = 2},
                new City() { Id = 5, Name = "Vienna", CountryID = 3},
                new City() { Id = 6, Name = "Graz", CountryID = 3},
                new City() { Id = 7, Name = "Klagenfurt", CountryID = 3},
                new City() { Id = 8, Name = "Berlin", CountryID = 4},
                new City() { Id = 9, Name = "London", CountryID = 10},
                new City() { Id = 10, Name = "Glasgow", CountryID = 10}
                );

            /*context.Prices.AddOrUpdate(prop => prop.Id,
                new Prices() { Id = 1, Year = 2020, ApartmentID = 1}

                );*/
        }
    }
}
