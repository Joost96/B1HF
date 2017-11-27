namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuisine : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cuisines",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CuisineActivities",
                c => new
                    {
                        Cuisine_Id = c.Int(nullable: false),
                        Activity_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Cuisine_Id, t.Activity_Id })
                .ForeignKey("dbo.Cuisines", t => t.Cuisine_Id, cascadeDelete: true)
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Cuisine_Id)
                .Index(t => t.Activity_Id);
            
            AlterColumn("dbo.Locations", "Lognitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Locations", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CuisineActivities", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.CuisineActivities", "Cuisine_Id", "dbo.Cuisines");
            DropIndex("dbo.CuisineActivities", new[] { "Activity_Id" });
            DropIndex("dbo.CuisineActivities", new[] { "Cuisine_Id" });
            AlterColumn("dbo.Locations", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Lognitude", c => c.Double(nullable: false));
            DropTable("dbo.CuisineActivities");
            DropTable("dbo.Cuisines");
        }
    }
}
