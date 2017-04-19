namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressForeignKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ReceveAddresses", "UserAccount_UserId", "dbo.UserAccounts");
            DropIndex("dbo.ReceveAddresses", new[] { "UserAccount_UserId" });
            RenameColumn(table: "dbo.ReceveAddresses", name: "UserAccount_UserId", newName: "AccountId");
            AlterColumn("dbo.ReceveAddresses", "AccountId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReceveAddresses", "AccountId");
            AddForeignKey("dbo.ReceveAddresses", "AccountId", "dbo.UserAccounts", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceveAddresses", "AccountId", "dbo.UserAccounts");
            DropIndex("dbo.ReceveAddresses", new[] { "AccountId" });
            AlterColumn("dbo.ReceveAddresses", "AccountId", c => c.Int());
            RenameColumn(table: "dbo.ReceveAddresses", name: "AccountId", newName: "UserAccount_UserId");
            CreateIndex("dbo.ReceveAddresses", "UserAccount_UserId");
            AddForeignKey("dbo.ReceveAddresses", "UserAccount_UserId", "dbo.UserAccounts", "UserId");
        }
    }
}
