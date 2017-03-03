namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveProfile : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Profiles", "Artister_ArtisterId", "dbo.Artisters");
            DropIndex("dbo.Profiles", new[] { "Artister_ArtisterId" });
            DropTable("dbo.Profiles");
            DropTable("dbo.Artisters");
        }
        
        public override void Down()
        {
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
                "dbo.Profiles",
                c => new
                    {
                        ProfileId = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Image = c.String(),
                        Artister_ArtisterId = c.Int(),
                    })
                .PrimaryKey(t => t.ProfileId);
            
            CreateIndex("dbo.Profiles", "Artister_ArtisterId");
            AddForeignKey("dbo.Profiles", "Artister_ArtisterId", "dbo.Artisters", "ArtisterId");
        }
    }
}
