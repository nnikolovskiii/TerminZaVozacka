namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateAndTime : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Prijavas", "DateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Prijavas", "DateTime", c => c.DateTime(nullable: false));
        }
    }
}
