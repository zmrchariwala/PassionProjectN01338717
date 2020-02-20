namespace PassionProject_N01338717.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initials : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Renters",
                c => new
                    {
                        RenterID = c.Int(nullable: false, identity: true),
                        RenterFname = c.String(),
                        RenterLname = c.String(),
                        RenterEmail = c.String(),
                        RenterAddress = c.String(),
                        RenterDOB = c.String(),
                        RenterUsername = c.String(),
                        RenterPassword = c.String(),
                    })
                .PrimaryKey(t => t.RenterID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Renters");
        }
    }
}
