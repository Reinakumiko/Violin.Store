namespace Violin.Store.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifyGiveways : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Giveaways", "Discography_DiscographyId", "dbo.Discographies");
            DropIndex("dbo.Giveaways", new[] { "Discography_DiscographyId" });
            RenameColumn(table: "dbo.Giveaways", name: "Discography_DiscographyId", newName: "_idDiscography");
            AlterColumn("dbo.Giveaways", "_idDiscography", c => c.Int(nullable: false));
            CreateIndex("dbo.Giveaways", "_idDiscography");
            AddForeignKey("dbo.Giveaways", "_idDiscography", "dbo.Discographies", "DiscographyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Giveaways", "_idDiscography", "dbo.Discographies");
            DropIndex("dbo.Giveaways", new[] { "_idDiscography" });
            AlterColumn("dbo.Giveaways", "_idDiscography", c => c.Int());
            RenameColumn(table: "dbo.Giveaways", name: "_idDiscography", newName: "Discography_DiscographyId");
            CreateIndex("dbo.Giveaways", "Discography_DiscographyId");
            AddForeignKey("dbo.Giveaways", "Discography_DiscographyId", "dbo.Discographies", "DiscographyId");
        }
    }
}
