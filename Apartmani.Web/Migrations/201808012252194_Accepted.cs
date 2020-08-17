namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Accepted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Inquiries", "Accepted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Inquiries", "Approved");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inquiries", "Approved", c => c.Boolean(nullable: false));
            DropColumn("dbo.Inquiries", "Accepted");
        }
    }
}
