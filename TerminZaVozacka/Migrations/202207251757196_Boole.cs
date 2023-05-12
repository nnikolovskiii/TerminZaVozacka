namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Boole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "IsAccepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "IsAccepted");
        }
    }
}
