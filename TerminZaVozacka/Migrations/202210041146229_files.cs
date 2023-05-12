namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class files : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Zdravstveno", c => c.Int(nullable: false));
            AddColumn("dbo.Prijavas", "Obrazovanie", c => c.Int(nullable: false));
            AddColumn("dbo.Prijavas", "PotvrdaZaCasovi", c => c.Int(nullable: false));
            AddColumn("dbo.Prijavas", "Uplatnica", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "Uplatnica");
            DropColumn("dbo.Prijavas", "PotvrdaZaCasovi");
            DropColumn("dbo.Prijavas", "Obrazovanie");
            DropColumn("dbo.Prijavas", "Zdravstveno");
        }
    }
}
