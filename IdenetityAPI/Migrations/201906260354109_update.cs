namespace IdenetityAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Products", "ProductDetails");
            DropColumn("dbo.Products", "CreateDate");
            DropColumn("dbo.Products", "ModifedeDate");
            DropColumn("dbo.Products", "isFeatured");
            DropColumn("dbo.Products", "Quantity");
            DropColumn("dbo.Products", "Sale");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Products", "Sale", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "Quantity", c => c.Double(nullable: false));
            AddColumn("dbo.Products", "isFeatured", c => c.String());
            AddColumn("dbo.Products", "ModifedeDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "CreateDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Products", "ProductDetails", c => c.String());
        }
    }
}
