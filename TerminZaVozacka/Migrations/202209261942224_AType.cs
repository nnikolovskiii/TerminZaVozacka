namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Broj", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "Broj");
        }
    }
}
