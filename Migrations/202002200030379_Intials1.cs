namespace PassionProject_N01338717.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intials1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bookings",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        RenterID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Cars", t => t.CarID, cascadeDelete: true)
                .ForeignKey("dbo.Renters", t => t.RenterID, cascadeDelete: true)
                .Index(t => t.RenterID)
                .Index(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bookings", "RenterID", "dbo.Renters");
            DropForeignKey("dbo.Bookings", "CarID", "dbo.Cars");
            DropIndex("dbo.Bookings", new[] { "CarID" });
            DropIndex("dbo.Bookings", new[] { "RenterID" });
            DropTable("dbo.Bookings");
        }
    }
}
