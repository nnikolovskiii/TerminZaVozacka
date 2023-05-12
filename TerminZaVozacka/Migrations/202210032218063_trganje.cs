namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class trganje : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Prijavas", "Name", c => c.String());
            AlterColumn("dbo.Prijavas", "Surname", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prijavas", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "Name", c => c.String(nullable: false));
        }
    }
}
