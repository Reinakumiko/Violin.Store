namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyReceiveAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReceveAddresses", "PostCode", c => c.String());
            AddColumn("dbo.ReceveAddresses", "Default", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReceveAddresses", "Default");
            DropColumn("dbo.ReceveAddresses", "PostCode");
        }
    }
}
