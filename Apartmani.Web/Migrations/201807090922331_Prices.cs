namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prices : DbMigration
    {

        public override void Up()
        {
            CreateTable(
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.Int(nullable: false),
                        ApartmentID = c.Int(nullable: false),
                        January = c.Int(nullable: false),
                        Fabruary = c.Int(nullable: false),
                        March = c.Int(nullable: false),
                        April = c.Int(nullable: false),
                        May = c.Int(nullable: false),
                        June = c.Int(nullable: false),
                        July = c.Int(nullable: false),
                        August = c.Int(nullable: false),
                        Septembar = c.Int(nullable: false),
                        Octobar = c.Int(nullable: false),
                        Novembar = c.Int(nullable: false),
                        Decembar = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.ApartmentID)
                .Index(t => t.ApartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prices", "ApartmentID", "dbo.Apartments");
            DropIndex("dbo.Prices", new[] { "ApartmentID" });
            DropTable("dbo.Prices");
        }
    }
}
