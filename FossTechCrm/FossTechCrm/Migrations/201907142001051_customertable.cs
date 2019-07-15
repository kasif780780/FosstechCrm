namespace FossTechCrm.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class customertable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Company = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Street = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Zip = c.String(),
                        Country = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Customers");
        }
    }
}
