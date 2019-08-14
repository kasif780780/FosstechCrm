namespace FossTechCrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class income : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Expanses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Currency = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Purpose = c.String(),
                        DateOfSpend = c.String(),
                        Marchant = c.String(),
                        Category = c.String(),
                        Reimbursable = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Incomes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IncomeDate = c.String(),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Incomes");
            DropTable("dbo.Expanses");
        }
    }
}
