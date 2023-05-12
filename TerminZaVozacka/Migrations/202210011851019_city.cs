namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class city : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "City", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "City");
        }
    }
}
