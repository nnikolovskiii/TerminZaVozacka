﻿namespace TerminZaVozacka.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Prijavas", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prijavas", "UserName");
        }
    }
}
