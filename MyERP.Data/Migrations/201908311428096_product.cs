namespace MyERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class product : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "CanBePurchased", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "CanBeSold", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "NotCanBePurchased");
            DropColumn("dbo.Products", "NotCanBeSold");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "NotCanBeSold", c => c.Boolean(nullable: false));
            AddColumn("dbo.Products", "NotCanBePurchased", c => c.Boolean(nullable: false));
            DropColumn("dbo.Products", "CanBeSold");
            DropColumn("dbo.Products", "CanBePurchased");
        }
    }
}
