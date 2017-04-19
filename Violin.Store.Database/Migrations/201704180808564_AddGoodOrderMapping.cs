namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGoodOrderMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Goods_ProductId", "dbo.Goods");
            DropIndex("dbo.Orders", new[] { "Goods_ProductId" });
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductId })
                .ForeignKey("dbo.Orders", t => t.OrderID, cascadeDelete: true)
                .ForeignKey("dbo.Goods", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderID)
                .Index(t => t.ProductId);
            
            AddColumn("dbo.Orders", "OrderNumber", c => c.String());
            DropColumn("dbo.Orders", "Goods_ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Goods_ProductId", c => c.Int());
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Goods");
            DropForeignKey("dbo.OrderProduct", "OrderID", "dbo.Orders");
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            DropIndex("dbo.OrderProduct", new[] { "OrderID" });
            DropColumn("dbo.Orders", "OrderNumber");
            DropTable("dbo.OrderProduct");
            CreateIndex("dbo.Orders", "Goods_ProductId");
            AddForeignKey("dbo.Orders", "Goods_ProductId", "dbo.Goods", "ProductId");
        }
    }
}
