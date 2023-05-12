namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class scheduler : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SchedulerEvents");
        }
    }
}
