namespace FossTechCrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class productTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        ProductCategory = c.String(),
                        VendorName = c.String(),
                        Manufacturer = c.String(),
                        SalesEndDate = c.String(),
                        SalesStartDate = c.String(),
                        SupportStartDate = c.String(),
                        SupportEndDate = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Tax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(),
                        Description = c.String(),
                        IsStock = c.Boolean(),
                        IsActive = c.Boolean(),
                    })
                .PrimaryKey(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
