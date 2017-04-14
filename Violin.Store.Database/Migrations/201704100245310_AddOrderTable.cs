namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOrderTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAccounts", "Access_UserId", "dbo.UserAccounts");
            DropIndex("dbo.UserAccounts", new[] { "Access_UserId" });
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        State = c.Int(nullable: false),
                        Account_UserId = c.Int(),
                        Address_RecevingId = c.Int(),
                        Goods_ProductId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.UserAccounts", t => t.Account_UserId)
                .ForeignKey("dbo.ReceveAddresses", t => t.Address_RecevingId)
                .ForeignKey("dbo.Goods", t => t.Goods_ProductId)
                .Index(t => t.Account_UserId)
                .Index(t => t.Address_RecevingId)
                .Index(t => t.Goods_ProductId);
            
            AddColumn("dbo.UserAccounts", "Access", c => c.Int(nullable: false));
            DropColumn("dbo.UserAccounts", "Access_UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserAccounts", "Access_UserId", c => c.Int());
            DropForeignKey("dbo.Orders", "Goods_ProductId", "dbo.Goods");
            DropForeignKey("dbo.Orders", "Address_RecevingId", "dbo.ReceveAddresses");
            DropForeignKey("dbo.Orders", "Account_UserId", "dbo.UserAccounts");
            DropIndex("dbo.Orders", new[] { "Goods_ProductId" });
            DropIndex("dbo.Orders", new[] { "Address_RecevingId" });
            DropIndex("dbo.Orders", new[] { "Account_UserId" });
            DropColumn("dbo.UserAccounts", "Access");
            DropTable("dbo.Orders");
            CreateIndex("dbo.UserAccounts", "Access_UserId");
            AddForeignKey("dbo.UserAccounts", "Access_UserId", "dbo.UserAccounts", "UserId");
        }
    }
}
