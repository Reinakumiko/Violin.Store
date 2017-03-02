namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyTables : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Discographies", "IncludedCount");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Discographies", "IncludedCount", c => c.Int(nullable: false));
        }
    }
}
