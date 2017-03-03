namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Discographies", "Price", c => c.Double(nullable: false));
            AddColumn("dbo.Goods", "Price", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goods", "Price");
            DropColumn("dbo.Discographies", "Price");
        }
    }
}
