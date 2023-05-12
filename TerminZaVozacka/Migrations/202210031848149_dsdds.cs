namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dsdds : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "DateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "DateTime");
        }
    }
}
