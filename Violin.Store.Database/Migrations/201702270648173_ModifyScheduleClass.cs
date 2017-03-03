namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyScheduleClass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Schedules", "StartTime", c => c.DateTime());
            AddColumn("dbo.Schedules", "EndTime", c => c.DateTime());
            DropColumn("dbo.Schedules", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Schedules", "DateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Schedules", "EndTime");
            DropColumn("dbo.Schedules", "StartTime");
        }
    }
}
