namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModityGoodsTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Goods", "ImageUrl", c => c.String());
            AddColumn("dbo.Goods", "State", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Goods", "State");
            DropColumn("dbo.Goods", "ImageUrl");
        }
    }
}
