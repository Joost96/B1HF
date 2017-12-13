namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cuisinemapping2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.ActivityCuisines", name: "Cuisine_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ActivityCuisines", name: "Activity_Id", newName: "Cuisine_Id");
            RenameColumn(table: "dbo.ActivityCuisines", name: "__mig_tmp__0", newName: "Activity_Id");
            RenameIndex(table: "dbo.ActivityCuisines", name: "IX_Cuisine_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ActivityCuisines", name: "IX_Activity_Id", newName: "IX_Cuisine_Id");
            RenameIndex(table: "dbo.ActivityCuisines", name: "__mig_tmp__0", newName: "IX_Activity_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.ActivityCuisines", name: "IX_Activity_Id", newName: "__mig_tmp__0");
            RenameIndex(table: "dbo.ActivityCuisines", name: "IX_Cuisine_Id", newName: "IX_Activity_Id");
            RenameIndex(table: "dbo.ActivityCuisines", name: "__mig_tmp__0", newName: "IX_Cuisine_Id");
            RenameColumn(table: "dbo.ActivityCuisines", name: "Activity_Id", newName: "__mig_tmp__0");
            RenameColumn(table: "dbo.ActivityCuisines", name: "Cuisine_Id", newName: "Activity_Id");
            RenameColumn(table: "dbo.ActivityCuisines", name: "__mig_tmp__0", newName: "Cuisine_Id");
        }
    }
}
