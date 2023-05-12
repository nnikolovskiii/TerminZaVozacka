namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imeIPrezime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Name", c => c.String(nullable: false));
            AddColumn("dbo.Prijavas", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "Surname");
            DropColumn("dbo.Prijavas", "Name");
        }
    }
}
