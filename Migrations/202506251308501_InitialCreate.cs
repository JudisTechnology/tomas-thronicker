namespace DemoEPS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Coupons", "IsSent", c => c.Boolean(nullable: false));
            DropColumn("dbo.Coupons", "IsUsed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Coupons", "IsUsed", c => c.Boolean(nullable: false));
            DropColumn("dbo.Coupons", "IsSent");
        }
    }
}
