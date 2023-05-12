namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Prijavas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "PrethodnaVozackaId", c => c.Int());
            DropColumn("dbo.Prijavas", "Broj");
            DropColumn("dbo.Prijavas", "Ime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prijavas", "Ime", c => c.String());
            AddColumn("dbo.Prijavas", "Broj", c => c.Int());
            DropColumn("dbo.Prijavas", "PrethodnaVozackaId");
        }
    }
}
