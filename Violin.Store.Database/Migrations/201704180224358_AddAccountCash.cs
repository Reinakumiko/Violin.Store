namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAccountCash : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ShoppingCarts", "Account_UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.ShoppingCarts", "Goods_ProductId", "dbo.Goods");
            DropIndex("dbo.ShoppingCarts", new[] { "Account_UserId" });
            DropIndex("dbo.ShoppingCarts", new[] { "Goods_ProductId" });
            RenameColumn(table: "dbo.ShoppingCarts", name: "Account_UserId", newName: "_idAccounts");
            RenameColumn(table: "dbo.ShoppingCarts", name: "Goods_ProductId", newName: "_idGoods");
            AddColumn("dbo.UserAccounts", "Cash", c => c.Double(nullable: false));
            AlterColumn("dbo.ShoppingCarts", "_idAccounts", c => c.Int(nullable: false));
            AlterColumn("dbo.ShoppingCarts", "_idGoods", c => c.Int(nullable: false));
            CreateIndex("dbo.ShoppingCarts", "_idGoods");
            CreateIndex("dbo.ShoppingCarts", "_idAccounts");
            AddForeignKey("dbo.ShoppingCarts", "_idAccounts", "dbo.UserAccounts", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.ShoppingCarts", "_idGoods", "dbo.Goods", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "_idGoods", "dbo.Goods");
            DropForeignKey("dbo.ShoppingCarts", "_idAccounts", "dbo.UserAccounts");
            DropIndex("dbo.ShoppingCarts", new[] { "_idAccounts" });
            DropIndex("dbo.ShoppingCarts", new[] { "_idGoods" });
            AlterColumn("dbo.ShoppingCarts", "_idGoods", c => c.Int());
            AlterColumn("dbo.ShoppingCarts", "_idAccounts", c => c.Int());
            DropColumn("dbo.UserAccounts", "Cash");
            RenameColumn(table: "dbo.ShoppingCarts", name: "_idGoods", newName: "Goods_ProductId");
            RenameColumn(table: "dbo.ShoppingCarts", name: "_idAccounts", newName: "Account_UserId");
            CreateIndex("dbo.ShoppingCarts", "Goods_ProductId");
            CreateIndex("dbo.ShoppingCarts", "Account_UserId");
            AddForeignKey("dbo.ShoppingCarts", "Goods_ProductId", "dbo.Goods", "ProductId");
            AddForeignKey("dbo.ShoppingCarts", "Account_UserId", "dbo.UserAccounts", "UserId");
        }
    }
}
