namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Availabilitiy : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inquiries", "Availability", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Inquiries", "Availability");
        }
    }
}
