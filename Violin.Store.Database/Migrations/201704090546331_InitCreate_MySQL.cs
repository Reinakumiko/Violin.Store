namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitCreate_MySQL : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(unicode: false),
                        Account = c.String(unicode: false),
                        Password = c.String(unicode: false),
                        Salt = c.String(unicode: false),
                        EmailAddress = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        Access = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.ReceveAddresses",
                c => new
                    {
                        RecevingId = c.Int(nullable: false, identity: true),
                        Consignee = c.String(unicode: false),
                        Address = c.String(unicode: false),
                        PhoneNumber = c.String(unicode: false),
                        UserAccount_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.RecevingId)
                .ForeignKey("dbo.UserAccounts", t => t.UserAccount_UserId)
                .Index(t => t.UserAccount_UserId);
            
            CreateTable(
                "dbo.Discographies",
                c => new
                    {
                        DiscographyId = c.Int(nullable: false, identity: true),
                        CoverImage = c.String(unicode: false),
                        Title = c.String(unicode: false),
                        Subtitle = c.String(unicode: false),
                        Description = c.String(unicode: false),
                        OnSaleTime = c.DateTime(nullable: false, precision: 0),
                        ProductNumber = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DiscographyId);
            
            CreateTable(
                "dbo.Giveaways",
                c => new
                    {
                        GivewayId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Discography_DiscographyId = c.Int(),
                    })
                .PrimaryKey(t => t.GivewayId)
                .ForeignKey("dbo.Discographies", t => t.Discography_DiscographyId)
                .Index(t => t.Discography_DiscographyId);
            
            CreateTable(
                "dbo.IncludedTracks",
                c => new
                    {
                        Track = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        LyricsBy = c.String(unicode: false),
                        Composer = c.String(unicode: false),
                        Arranger = c.String(unicode: false),
                        DiscographyId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Track)
                .ForeignKey("dbo.Discographies", t => t.DiscographyId, cascadeDelete: true)
                .Index(t => t.DiscographyId);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(unicode: false),
                        Price = c.Double(nullable: false),
                        Note = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        ReleaseTime = c.DateTime(nullable: false, precision: 0),
                        Type = c.Int(nullable: false),
                        Title = c.String(unicode: false),
                        Content = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.NewsID);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        StartTime = c.DateTime(precision: 0),
                        EndTime = c.DateTime(precision: 0),
                        BangumiName = c.String(unicode: false),
                        BangumiUrl = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncludedTracks", "DiscographyId", "dbo.Discographies");
            DropForeignKey("dbo.Giveaways", "Discography_DiscographyId", "dbo.Discographies");
            DropForeignKey("dbo.ReceveAddresses", "UserAccount_UserId", "dbo.UserAccounts");
            DropIndex("dbo.IncludedTracks", new[] { "DiscographyId" });
            DropIndex("dbo.Giveaways", new[] { "Discography_DiscographyId" });
            DropIndex("dbo.ReceveAddresses", new[] { "UserAccount_UserId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.News");
            DropTable("dbo.Goods");
            DropTable("dbo.IncludedTracks");
            DropTable("dbo.Giveaways");
            DropTable("dbo.Discographies");
            DropTable("dbo.ReceveAddresses");
            DropTable("dbo.UserAccounts");
        }
    }
}
