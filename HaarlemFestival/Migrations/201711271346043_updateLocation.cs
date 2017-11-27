namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateLocation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Locations", "Lognitude", c => c.Double(nullable: false));
            AlterColumn("dbo.Locations", "Latitude", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Locations", "Latitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Locations", "Lognitude", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
