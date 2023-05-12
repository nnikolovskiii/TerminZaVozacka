namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class decorator : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Prijava_Id", c => c.Int());
            CreateIndex("dbo.Prijavas", "Prijava_Id");
            AddForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas");
            DropIndex("dbo.Prijavas", new[] { "Prijava_Id" });
            DropColumn("dbo.Prijavas", "Prijava_Id");
        }
    }
}
