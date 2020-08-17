namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorGroupValidation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.VisitorGroups", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.VisitorGroups", "Name", c => c.String());
        }
    }
}
