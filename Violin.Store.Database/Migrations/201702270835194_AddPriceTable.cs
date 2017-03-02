namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPriceTable : DbMigration
    {
        public override void Up()
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
            
            AddColumn("dbo.Discographies", "Price_PriceId", c => c.Int());
            AddColumn("dbo.Goods", "Price_PriceId", c => c.Int());
            CreateIndex("dbo.Discographies", "Price_PriceId");
            CreateIndex("dbo.Goods", "Price_PriceId");
            AddForeignKey("dbo.Discographies", "Price_PriceId", "dbo.SalePrices", "PriceId");
            AddForeignKey("dbo.Goods", "Price_PriceId", "dbo.SalePrices", "PriceId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goods", "Price_PriceId", "dbo.SalePrices");
            DropForeignKey("dbo.Discographies", "Price_PriceId", "dbo.SalePrices");
            DropIndex("dbo.Goods", new[] { "Price_PriceId" });
            DropIndex("dbo.Discographies", new[] { "Price_PriceId" });
            DropColumn("dbo.Goods", "Price_PriceId");
            DropColumn("dbo.Discographies", "Price_PriceId");
            DropTable("dbo.SalePrices");
        }
    }
}
