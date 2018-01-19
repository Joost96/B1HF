namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class questionaangepast : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "Spreker", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Questions", "Spreker");
        }
    }
}
