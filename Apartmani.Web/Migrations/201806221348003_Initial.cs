namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Apartments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Size = c.Int(nullable: false),
                        Bedrooms = c.Int(nullable: false),
                        Beds = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdentificationType = c.Int(nullable: false),
                        IdentificationNumber = c.String(),
                        LastName = c.String(),
                        FirstName = c.String(),
                        MiddleName = c.String(),
                        Sex = c.Int(nullable: false),
                        ResidenceCountryID = c.Int(nullable: false),
                        ResidenceCityID = c.Int(nullable: false),
                        ResidenceAddress = c.String(),
                        BirthCountryID = c.Int(nullable: false),
                        BirthCityID = c.Int(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        CitizenshipID = c.Int(nullable: false),
                        TaxpayerCategory = c.Int(nullable: false),
                        ArrivalOrganization = c.Int(nullable: false),
                        TypeOfService = c.Int(nullable: false),
                        VisitorGroupID = c.Int(nullable: false),
                        Country_Id = c.Int(),
                        City_Id = c.Int(),
                        Apartment_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.Country_Id)
                .ForeignKey("dbo.Cities", t => t.City_Id)
                .ForeignKey("dbo.Cities", t => t.BirthCityID)
                .ForeignKey("dbo.Countries", t => t.BirthCountryID)
                .ForeignKey("dbo.Countries", t => t.CitizenshipID)
                .ForeignKey("dbo.Cities", t => t.ResidenceCityID)
                .ForeignKey("dbo.Countries", t => t.ResidenceCountryID)
                .ForeignKey("dbo.VisitorGroups", t => t.VisitorGroupID)
                .ForeignKey("dbo.Apartments", t => t.Apartment_Id)
                .Index(t => t.ResidenceCountryID)
                .Index(t => t.ResidenceCityID)
                .Index(t => t.BirthCountryID)
                .Index(t => t.BirthCityID)
                .Index(t => t.CitizenshipID)
                .Index(t => t.VisitorGroupID)
                .Index(t => t.Country_Id)
                .Index(t => t.City_Id)
                .Index(t => t.Apartment_Id);
            
            CreateTable(
                "dbo.Cities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CountryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryID)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitorGroups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        TimeOfCreation = c.DateTime(nullable: false),
                        ApartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.ApartmentID)
                .Index(t => t.ApartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Visitors", "Apartment_Id", "dbo.Apartments");
            DropForeignKey("dbo.Visitors", "VisitorGroupID", "dbo.VisitorGroups");
            DropForeignKey("dbo.VisitorGroups", "ApartmentID", "dbo.Apartments");
            DropForeignKey("dbo.Visitors", "ResidenceCountryID", "dbo.Countries");
            DropForeignKey("dbo.Visitors", "ResidenceCityID", "dbo.Cities");
            DropForeignKey("dbo.Visitors", "CitizenshipID", "dbo.Countries");
            DropForeignKey("dbo.Visitors", "BirthCountryID", "dbo.Countries");
            DropForeignKey("dbo.Visitors", "BirthCityID", "dbo.Cities");
            DropForeignKey("dbo.Visitors", "City_Id", "dbo.Cities");
            DropForeignKey("dbo.Cities", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.Visitors", "Country_Id", "dbo.Countries");
            DropIndex("dbo.VisitorGroups", new[] { "ApartmentID" });
            DropIndex("dbo.Cities", new[] { "CountryID" });
            DropIndex("dbo.Visitors", new[] { "Apartment_Id" });
            DropIndex("dbo.Visitors", new[] { "City_Id" });
            DropIndex("dbo.Visitors", new[] { "Country_Id" });
            DropIndex("dbo.Visitors", new[] { "VisitorGroupID" });
            DropIndex("dbo.Visitors", new[] { "CitizenshipID" });
            DropIndex("dbo.Visitors", new[] { "BirthCityID" });
            DropIndex("dbo.Visitors", new[] { "BirthCountryID" });
            DropIndex("dbo.Visitors", new[] { "ResidenceCityID" });
            DropIndex("dbo.Visitors", new[] { "ResidenceCountryID" });
            DropTable("dbo.VisitorGroups");
            DropTable("dbo.Countries");
            DropTable("dbo.Cities");
            DropTable("dbo.Visitors");
            DropTable("dbo.Apartments");
        }
    }
}
