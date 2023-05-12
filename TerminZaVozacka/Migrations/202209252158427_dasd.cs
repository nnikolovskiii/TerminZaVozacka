namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dasd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Ime", c => c.String());
            AddColumn("dbo.Prijavas", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Prijavas", "Prijava_Id", c => c.Int());
            CreateIndex("dbo.Prijavas", "Prijava_Id");
            AddForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Prijavas", "Prijava_Id", "dbo.Prijavas");
            DropIndex("dbo.Prijavas", new[] { "Prijava_Id" });
            DropColumn("dbo.Prijavas", "Prijava_Id");
            DropColumn("dbo.Prijavas", "Discriminator");
            DropColumn("dbo.Prijavas", "Ime");
        }
    }
}
