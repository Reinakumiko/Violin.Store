namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHserAccess : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReceveAddresses",
                c => new
                    {
                        RecevingId = c.Int(nullable: false, identity: true),
                        Consignee = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.String(),
                        UserAccount_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RecevingId)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserId)
                .Index(t => t.UserAccount_UserId);
            
            AddColumn("dbo.UserAccounts", "Access_UserId", c => c.Int());
            CreateIndex("dbo.UserAccounts", "Access_UserId");
            AddForeignKey("dbo.UserAccounts", "Access_UserId", "dbo.UserAccounts", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceveAddresses", "UserAccount_UserId", "dbo.UserAccounts");
            DropForeignKey("dbo.UserAccounts", "Access_UserId", "dbo.UserAccounts");
            DropIndex("dbo.ReceveAddresses", new[] { "UserAccount_UserId" });
            DropIndex("dbo.UserAccounts", new[] { "Access_UserId" });
            DropColumn("dbo.UserAccounts", "Access_UserId");
            DropTable("dbo.ReceveAddresses");
        }
    }
}
