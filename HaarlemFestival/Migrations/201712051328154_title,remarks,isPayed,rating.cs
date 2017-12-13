namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class titleremarksisPayedrating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsPayed", c => c.Boolean(nullable: false));
            AddColumn("dbo.OrderHasTickets", "Remarks", c => c.String());
            AddColumn("dbo.Activities", "Rating", c => c.Int(nullable: false));
            AddColumn("dbo.Pages", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Pages", "Titel");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pages", "Titel", c => c.String(nullable: false));
            DropColumn("dbo.Pages", "Title");
            DropColumn("dbo.Activities", "Rating");
            DropColumn("dbo.OrderHasTickets", "Remarks");
            DropColumn("dbo.Orders", "IsPayed");
        }
    }
}
