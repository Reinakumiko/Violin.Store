namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePrice : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Discographies", "Price_PriceId", "dbo.SalePrices");
            DropForeignKey("dbo.Goods", "Price_PriceId", "dbo.SalePrices");
            DropIndex("dbo.Discographies", new[] { "Price_PriceId" });
            DropIndex("dbo.Goods", new[] { "Price_PriceId" });
            DropColumn("dbo.Discographies", "Price_PriceId");
            DropColumn("dbo.Goods", "Price_PriceId");
            DropTable("dbo.SalePrices");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SalePrices",
                c => new
                    {
                        PriceId = c.Int(nullable: false, identity: true),
                        Price = c.Double(nullable: false),
                        IsIncludeTax = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.PriceId);
            
            AddColumn("dbo.Goods", "Price_PriceId", c => c.Int());
            AddColumn("dbo.Discographies", "Price_PriceId", c => c.Int());
            CreateIndex("dbo.Goods", "Price_PriceId");
            CreateIndex("dbo.Discographies", "Price_PriceId");
            AddForeignKey("dbo.Goods", "Price_PriceId", "dbo.SalePrices", "PriceId");
            AddForeignKey("dbo.Discographies", "Price_PriceId", "dbo.SalePrices", "PriceId");
        }
    }
}
