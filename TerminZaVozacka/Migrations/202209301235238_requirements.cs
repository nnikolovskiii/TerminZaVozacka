namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requirements : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "Requirements", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "Requirements");
        }
    }
}
