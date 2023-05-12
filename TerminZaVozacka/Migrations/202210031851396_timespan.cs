namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timespan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "Time", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "Time");
        }
    }
}
