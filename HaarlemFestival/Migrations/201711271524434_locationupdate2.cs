namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class locationupdate2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Lognitude", c => c.Decimal(nullable: false, precision: 11, scale: 8));
            AlterColumn("dbo.Locations", "Latitude", c => c.Decimal(nullable: false, precision: 11, scale: 8));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Latitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Lognitude", c => c.Double(nullable: false));
        }
    }
}
