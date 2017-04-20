namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeOrderCartTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderProduct", "OrderID", "dbo.Orders");
            DropForeignKey("dbo.OrderProduct", "ProductId", "dbo.Goods");
            DropForeignKey("dbo.ShoppingCarts", "_idGoods", "dbo.Goods");
            DropIndex("dbo.ShoppingCarts", new[] { "_idGoods" });
            DropIndex("dbo.OrderProduct", new[] { "OrderID" });
            DropIndex("dbo.OrderProduct", new[] { "ProductId" });
            CreateTable(
                "dbo.ShoppingProducts",
                c => new
                    {
                        InfoId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Orders_OrderID = c.Int(),
                    })
                .PrimaryKey(t => t.InfoId)
                .ForeignKey("dbo.Goods", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.Orders_OrderID)
                .Index(t => t.ProductId)
                .Index(t => t.Orders_OrderID);
            
            AddColumn("dbo.ShoppingCarts", "_idInfos", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "_idInfos");
            AddForeignKey("dbo.ShoppingCarts", "_idInfos", "dbo.ShoppingProducts", "InfoId", cascadeDelete: true);
            DropColumn("dbo.ShoppingCarts", "Quantity");
            DropColumn("dbo.ShoppingCarts", "_idGoods");
            DropTable("dbo.OrderProduct");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderProduct",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderID, t.ProductId });
            
            AddColumn("dbo.ShoppingCarts", "_idGoods", c => c.Int(nullable: false));
            AddColumn("dbo.ShoppingCarts", "Quantity", c => c.Int(nullable: false));
            DropForeignKey("dbo.ShoppingCarts", "_idInfos", "dbo.ShoppingProducts");
            DropForeignKey("dbo.ShoppingProducts", "Orders_OrderID", "dbo.Orders");
            DropForeignKey("dbo.ShoppingProducts", "ProductId", "dbo.Goods");
            DropIndex("dbo.ShoppingCarts", new[] { "_idInfos" });
            DropIndex("dbo.ShoppingProducts", new[] { "Orders_OrderID" });
            DropIndex("dbo.ShoppingProducts", new[] { "ProductId" });
            DropColumn("dbo.ShoppingCarts", "_idInfos");
            DropTable("dbo.ShoppingProducts");
            CreateIndex("dbo.OrderProduct", "ProductId");
            CreateIndex("dbo.OrderProduct", "OrderID");
            CreateIndex("dbo.ShoppingCarts", "_idGoods");
            AddForeignKey("dbo.ShoppingCarts", "_idGoods", "dbo.Goods", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProduct", "ProductId", "dbo.Goods", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.OrderProduct", "OrderID", "dbo.Orders", "OrderID", cascadeDelete: true);
        }
    }
}
