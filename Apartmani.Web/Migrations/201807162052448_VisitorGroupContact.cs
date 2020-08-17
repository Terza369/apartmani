namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class VisitorGroupContact : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorGroups", "BrojMobitela", c => c.String());
            AddColumn("dbo.VisitorGroups", "Email", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorGroups", "Email");
            DropColumn("dbo.VisitorGroups", "BrojMobitela");
        }
    }
}
