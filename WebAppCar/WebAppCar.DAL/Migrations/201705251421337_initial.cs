namespace WebAppCar.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Model = c.String(),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Continent = c.String(),
                        NameOfContry = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CountryCars",
                c => new
                    {
                        Country_Id = c.Int(nullable: false),
                        Car_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Country_Id, t.Car_Id })
                .ForeignKey("dbo.Countries", t => t.Country_Id, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.Car_Id, cascadeDelete: true)
                .Index(t => t.Country_Id)
                .Index(t => t.Car_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CountryCars", "Car_Id", "dbo.Cars");
            DropForeignKey("dbo.CountryCars", "Country_Id", "dbo.Countries");
            DropIndex("dbo.CountryCars", new[] { "Car_Id" });
            DropIndex("dbo.CountryCars", new[] { "Country_Id" });
            DropTable("dbo.CountryCars");
            DropTable("dbo.Countries");
            DropTable("dbo.Cars");
        }
    }
}
