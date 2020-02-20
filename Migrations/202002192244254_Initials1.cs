namespace PassionProject_N01338717.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarID = c.Int(nullable: false, identity: true),
                        Carmake = c.String(),
                        Carmodel = c.String(),
                        Caryear = c.String(),
                        Carcolor = c.String(),
                    })
                .PrimaryKey(t => t.CarID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Cars");
        }
    }
}
