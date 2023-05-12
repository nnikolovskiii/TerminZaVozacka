namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typeLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "Type", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "Type");
        }
    }
}
