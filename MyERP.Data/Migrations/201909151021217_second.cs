namespace MyERP.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Invoices", "Subtotal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "GrandTotal", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Invoices", "GrandTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Invoices", "Subtotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
