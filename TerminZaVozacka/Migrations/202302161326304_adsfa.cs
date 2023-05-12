namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adsfa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "PrijavaId", c => c.Int());
            AddColumn("dbo.Prijavas", "PrijavaId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "PrijavaId");
            DropColumn("dbo.Locations", "PrijavaId");
        }
    }
}
