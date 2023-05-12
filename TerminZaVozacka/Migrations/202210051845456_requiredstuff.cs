namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class requiredstuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "CreationTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Prijavas", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "Surname", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "Type", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "Category", c => c.String(nullable: false));
            AlterColumn("dbo.Prijavas", "IdentificationNumber", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Prijavas", "IdentificationNumber", c => c.String());
            AlterColumn("dbo.Prijavas", "Category", c => c.String());
            AlterColumn("dbo.Prijavas", "Type", c => c.String());
            AlterColumn("dbo.Prijavas", "UserName", c => c.String());
            AlterColumn("dbo.Prijavas", "Surname", c => c.String());
            AlterColumn("dbo.Prijavas", "Name", c => c.String());
            DropColumn("dbo.Prijavas", "CreationTime");
        }
    }
}
