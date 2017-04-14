namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShoppingCartTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        CartId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        Account_UserId = c.Int(),
                        Goods_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.CartId)
                .ForeignKey("dbo.UserAccounts", t => t.Account_UserId)
                .ForeignKey("dbo.Goods", t => t.Goods_ProductId)
                .Index(t => t.Account_UserId)
                .Index(t => t.Goods_ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "Goods_ProductId", "dbo.Goods");
            DropForeignKey("dbo.ShoppingCarts", "Account_UserId", "dbo.UserAccounts");
            DropIndex("dbo.ShoppingCarts", new[] { "Goods_ProductId" });
            DropIndex("dbo.ShoppingCarts", new[] { "Account_UserId" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
