namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vratiPovtorno : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas");
            DropIndex("dbo.Prijavas", new[] { "Prijava_Id" });
            DropColumn("dbo.Prijavas", "Prijava_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prijavas", "Prijava_Id", c => c.Int());
            CreateIndex("dbo.Prijavas", "Prijava_Id");
            AddForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas", "Id");
        }
    }
}
