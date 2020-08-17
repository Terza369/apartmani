namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdditionalBeds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Apartments", "AdditionalBeds", c => c.Int(nullable: false));
            DropColumn("dbo.Apartments", "Price");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Apartments", "Price", c => c.Int(nullable: false));
            DropColumn("dbo.Apartments", "AdditionalBeds");
        }
    }
}
