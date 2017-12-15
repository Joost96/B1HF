namespace HaarlemFestival.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderpaymentmethod : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "PaymentMethod", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "IsPayed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "IsPayed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "PaymentMethod");
        }
    }
}
