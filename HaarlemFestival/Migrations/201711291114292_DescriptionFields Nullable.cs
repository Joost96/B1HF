namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionFieldsNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Activities", "Title", c => c.String());
            AlterColumn("dbo.Activities", "DescriptionText", c => c.String());
            AlterColumn("dbo.PageDescriptions", "Title", c => c.String());
            AlterColumn("dbo.PageDescriptions", "DescriptionText", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PageDescriptions", "DescriptionText", c => c.String(nullable: false));
            AlterColumn("dbo.PageDescriptions", "Title", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "DescriptionText", c => c.String(nullable: false));
            AlterColumn("dbo.Activities", "Title", c => c.String(nullable: false));
        }
    }
}
