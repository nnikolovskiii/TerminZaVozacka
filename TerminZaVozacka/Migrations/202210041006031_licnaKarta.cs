namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class licnaKarta : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "LicnaKartaId", c => c.Int(nullable: false));
            DropTable("dbo.SchedulerEvents");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SchedulerEvents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Text = c.String(),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Prijavas", "LicnaKartaId");
        }
    }
}
