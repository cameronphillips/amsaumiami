namespace memberDatabasetest.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Signups",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        SchoolYear = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Major = c.String(nullable: false),
                        Specialty = c.String(nullable: false),
                        HasCar = c.Boolean(nullable: false),
                        Availability = c.String(nullable: false),
                        BrowardAvailable = c.Boolean(nullable: false),
                        VolunteerActivity = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Signups");
        }
    }
}
