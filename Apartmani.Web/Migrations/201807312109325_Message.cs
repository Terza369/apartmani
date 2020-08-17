namespace Apartmani.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Message : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.VisitorGroups", "Message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.VisitorGroups", "Message");
        }
    }
}
