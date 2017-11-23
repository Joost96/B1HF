namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Accounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Country = c.String(),
                        EmployeeType = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CustomerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Accounts", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.OrderHasTickets",
                c => new
                    {
                        Order_Id = c.Int(nullable: false),
                        Ticket_TimeSlot_Activity_Id = c.Int(nullable: false),
                        Ticket_TimeSlot_StartTime = c.DateTime(nullable: false),
                        Ticket_Type = c.Int(nullable: false),
                        Amount = c.Int(nullable: false),
                        TotalPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.Order_Id, t.Ticket_TimeSlot_Activity_Id, t.Ticket_TimeSlot_StartTime, t.Ticket_Type })
                .ForeignKey("dbo.Orders", t => t.Order_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => new { t.Ticket_TimeSlot_Activity_Id, t.Ticket_TimeSlot_StartTime, t.Ticket_Type }, cascadeDelete: true)
                .Index(t => t.Order_Id)
                .Index(t => new { t.Ticket_TimeSlot_Activity_Id, t.Ticket_TimeSlot_StartTime, t.Ticket_Type });
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        TimeSlot_Activity_Id = c.Int(nullable: false),
                        TimeSlot_StartTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.TimeSlot_Activity_Id, t.TimeSlot_StartTime, t.Type })
                .ForeignKey("dbo.TimeSlots", t => new { t.TimeSlot_Activity_Id, t.TimeSlot_StartTime }, cascadeDelete: true)
                .Index(t => new { t.TimeSlot_Activity_Id, t.TimeSlot_StartTime });
            
            CreateTable(
                "dbo.TimeSlots",
                c => new
                    {
                        Activity_Id = c.Int(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        TotalSeats = c.Int(nullable: false),
                        FreeSeats = c.Int(nullable: false),
                        Hall = c.String(),
                    })
                .PrimaryKey(t => new { t.Activity_Id, t.StartTime })
                .ForeignKey("dbo.Activities", t => t.Activity_Id, cascadeDelete: true)
                .Index(t => t.Activity_Id);
            
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Type = c.Int(nullable: false),
                        Location_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Locations", t => t.Location_Id, cascadeDelete: true)
                .Index(t => t.Location_Id);
            
            CreateTable(
                "dbo.ActivityDescriptions",
                c => new
                    {
                        Language = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                        Activity_ID = c.Int(nullable: false),
                        Title = c.String(nullable: false),
                        DescriptionText = c.String(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => new { t.Language, t.Section, t.Activity_ID })
                .ForeignKey("dbo.Activities", t => t.Activity_ID, cascadeDelete: true)
                .Index(t => t.Activity_ID);
            
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(nullable: false),
                        Street = c.String(nullable: false),
                        StreetNr = c.Int(nullable: false),
                        ZipCode = c.String(nullable: false),
                        Lognitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Latitude = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PageDescriptions",
                c => new
                    {
                        Language = c.Int(nullable: false),
                        Section = c.Int(nullable: false),
                        Page_Name = c.String(nullable: false, maxLength: 128),
                        Title = c.String(nullable: false),
                        DescriptionText = c.String(nullable: false),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => new { t.Language, t.Section, t.Page_Name })
                .ForeignKey("dbo.Pages", t => t.Page_Name, cascadeDelete: true)
                .Index(t => t.Page_Name);
            
            CreateTable(
                "dbo.Pages",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Titel = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PageDescriptions", "Page_Name", "dbo.Pages");
            DropForeignKey("dbo.OrderHasTickets", new[] { "Ticket_TimeSlot_Activity_Id", "Ticket_TimeSlot_StartTime", "Ticket_Type" }, "dbo.Tickets");
            DropForeignKey("dbo.Tickets", new[] { "TimeSlot_Activity_Id", "TimeSlot_StartTime" }, "dbo.TimeSlots");
            DropForeignKey("dbo.TimeSlots", "Activity_Id", "dbo.Activities");
            DropForeignKey("dbo.Activities", "Location_Id", "dbo.Locations");
            DropForeignKey("dbo.ActivityDescriptions", "Activity_ID", "dbo.Activities");
            DropForeignKey("dbo.OrderHasTickets", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Accounts");
            DropIndex("dbo.PageDescriptions", new[] { "Page_Name" });
            DropIndex("dbo.ActivityDescriptions", new[] { "Activity_ID" });
            DropIndex("dbo.Activities", new[] { "Location_Id" });
            DropIndex("dbo.TimeSlots", new[] { "Activity_Id" });
            DropIndex("dbo.Tickets", new[] { "TimeSlot_Activity_Id", "TimeSlot_StartTime" });
            DropIndex("dbo.OrderHasTickets", new[] { "Ticket_TimeSlot_Activity_Id", "Ticket_TimeSlot_StartTime", "Ticket_Type" });
            DropIndex("dbo.OrderHasTickets", new[] { "Order_Id" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropTable("dbo.Pages");
            DropTable("dbo.PageDescriptions");
            DropTable("dbo.Locations");
            DropTable("dbo.ActivityDescriptions");
            DropTable("dbo.Activities");
            DropTable("dbo.TimeSlots");
            DropTable("dbo.Tickets");
            DropTable("dbo.OrderHasTickets");
            DropTable("dbo.Orders");
            DropTable("dbo.Accounts");
        }
    }
}
