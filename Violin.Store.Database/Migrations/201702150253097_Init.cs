namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Nickname = c.String(),
                        Account = c.String(),
                        Password = c.String(),
                        Salt = c.String(),
                        EmailAddress = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Discographies",
                c => new
                    {
                        DiscographyId = c.Int(nullable: false, identity: true),
                        CoverImage = c.String(),
                        Title = c.String(),
                        Subtitle = c.String(),
                        Description = c.String(),
                        OnSaleTime = c.DateTime(nullable: false),
                        ProductNumber = c.String(),
                        IncludedCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DiscographyId);
            
            CreateTable(
                "dbo.Giveaways",
                c => new
                    {
                        GivewayId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
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
                        Name = c.String(),
                        LyricsBy = c.String(),
                        Composer = c.String(),
                        Arranger = c.String(),
                        Discography_DiscographyId = c.Int(),
                    })
                .PrimaryKey(t => t.Track)
                .ForeignKey("dbo.Discographies", t => t.Discography_DiscographyId)
                .Index(t => t.Discography_DiscographyId);
            
            CreateTable(
                "dbo.Goods",
                c => new
                    {
                        ProductId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Note = c.String(),
                    })
                .PrimaryKey(t => t.ProductId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        NewsID = c.Int(nullable: false, identity: true),
                        ReleaseTime = c.DateTime(nullable: false),
                        Type = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                    })
                .PrimaryKey(t => t.NewsID);
            
            CreateTable(
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Image = c.String(),
                        Artister_ArtisterId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileId)
                .ForeignKey("dbo.Artisters", t => t.Artister_ArtisterId)
                .Index(t => t.Artister_ArtisterId);
            
            CreateTable(
                "dbo.Artisters",
                c => new
                    {
                        ArtisterId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        EnglishName = c.String(),
                        BirthDay = c.DateTime(nullable: false),
                        BloodType = c.String(),
                        Height = c.Int(nullable: false),
                        BrithIn = c.String(),
                        Specialty = c.String(),
                        Hobby = c.String(),
                    })
                .PrimaryKey(t => t.ArtisterId);
            
            CreateTable(
                "dbo.Schedules",
                c => new
                    {
                        ScheduleId = c.Int(nullable: false, identity: true),
                        Type = c.Int(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        BangumiName = c.String(),
                        BangumiUrl = c.String(),
                    })
                .PrimaryKey(t => t.ScheduleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profiles", "Artister_ArtisterId", "dbo.Artisters");
            DropForeignKey("dbo.IncludedTracks", "Discography_DiscographyId", "dbo.Discographies");
            DropForeignKey("dbo.Giveaways", "Discography_DiscographyId", "dbo.Discographies");
            DropIndex("dbo.Profiles", new[] { "Artister_ArtisterId" });
            DropIndex("dbo.IncludedTracks", new[] { "Discography_DiscographyId" });
            DropIndex("dbo.Giveaways", new[] { "Discography_DiscographyId" });
            DropTable("dbo.Schedules");
            DropTable("dbo.Artisters");
            DropTable("dbo.Profiles");
            DropTable("dbo.News");
            DropTable("dbo.Goods");
            DropTable("dbo.IncludedTracks");
            DropTable("dbo.Giveaways");
            DropTable("dbo.Discographies");
            DropTable("dbo.UserAccounts");
        }
    }
}
