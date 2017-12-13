namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuisineUpdate : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CuisineActivities", newName: "ActivityCuisines");
            DropPrimaryKey("dbo.ActivityCuisines");
            AddPrimaryKey("dbo.ActivityCuisines", new[] { "Activity_Id", "Cuisine_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.ActivityCuisines");
            AddPrimaryKey("dbo.ActivityCuisines", new[] { "Cuisine_Id", "Activity_Id" });
            RenameTable(name: "dbo.ActivityCuisines", newName: "CuisineActivities");
        }
    }
}
