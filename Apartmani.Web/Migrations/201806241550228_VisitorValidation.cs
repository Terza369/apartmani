namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Visitors", "IdentificationNumber", c => c.String(nullable: false));
            AlterColumn("dbo.Visitors", "LastName", c => c.String(nullable: false));
            AlterColumn("dbo.Visitors", "FirstName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Visitors", "FirstName", c => c.String());
            AlterColumn("dbo.Visitors", "LastName", c => c.String());
            AlterColumn("dbo.Visitors", "IdentificationNumber", c => c.String());
        }
    }
}
