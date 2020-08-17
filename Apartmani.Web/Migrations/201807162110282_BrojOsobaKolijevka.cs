namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BrojOsobaKolijevka : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorGroups", "BrojOsoba", c => c.Int());
            AddColumn("dbo.VisitorGroups", "Kolijevka", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorGroups", "Kolijevka");
            DropColumn("dbo.VisitorGroups", "BrojOsoba");
        }
    }
}
