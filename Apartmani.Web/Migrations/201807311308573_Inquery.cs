namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inquery : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inquiries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateFrom = c.DateTime(nullable: false),
                        DateTo = c.DateTime(nullable: false),
                        ApartmentID = c.Int(nullable: false),
                        Persons = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(),
                        Message = c.String(),
                        Approved = c.Boolean(nullable: false),
                        Declined = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Apartments", t => t.ApartmentID)
                .Index(t => t.ApartmentID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inquiries", "ApartmentID", "dbo.Apartments");
            DropIndex("dbo.Inquiries", new[] { "ApartmentID" });
            DropTable("dbo.Inquiries");
        }
    }
}
