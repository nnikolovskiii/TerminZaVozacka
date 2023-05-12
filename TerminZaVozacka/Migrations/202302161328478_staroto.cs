namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staroto : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Locations", "PrijavaId");
            DropColumn("dbo.Prijavas", "PrijavaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prijavas", "PrijavaId", c => c.Int());
            AddColumn("dbo.Locations", "PrijavaId", c => c.Int());
        }
    }
}
