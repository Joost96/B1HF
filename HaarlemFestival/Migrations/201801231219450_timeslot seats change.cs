namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timeslotseatschange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TimeSlots", "OccupiedSeats", c => c.Int(nullable: false));
            DropColumn("dbo.TimeSlots", "FreeSeats");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TimeSlots", "FreeSeats", c => c.Int(nullable: false));
            DropColumn("dbo.TimeSlots", "OccupiedSeats");
        }
    }
}
