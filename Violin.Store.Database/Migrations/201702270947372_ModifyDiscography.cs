namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyDiscography : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IncludedTracks", "Discography_DiscographyId", "dbo.Discographies");
            DropIndex("dbo.IncludedTracks", new[] { "Discography_DiscographyId" });
            RenameColumn(table: "dbo.IncludedTracks", name: "Discography_DiscographyId", newName: "DiscographyId");
            AlterColumn("dbo.IncludedTracks", "DiscographyId", c => c.Int(nullable: false));
            CreateIndex("dbo.IncludedTracks", "DiscographyId");
            AddForeignKey("dbo.IncludedTracks", "DiscographyId", "dbo.Discographies", "DiscographyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IncludedTracks", "DiscographyId", "dbo.Discographies");
            DropIndex("dbo.IncludedTracks", new[] { "DiscographyId" });
            AlterColumn("dbo.IncludedTracks", "DiscographyId", c => c.Int());
            RenameColumn(table: "dbo.IncludedTracks", name: "DiscographyId", newName: "Discography_DiscographyId");
            CreateIndex("dbo.IncludedTracks", "Discography_DiscographyId");
            AddForeignKey("dbo.IncludedTracks", "Discography_DiscographyId", "dbo.Discographies", "DiscographyId");
        }
    }
}
