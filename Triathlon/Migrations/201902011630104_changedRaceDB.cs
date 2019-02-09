namespace Triathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedRaceDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Athlete", "RaceLevel", c => c.Int(nullable: false));
            DropColumn("dbo.Athlete", "RaceType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athlete", "RaceType", c => c.Int(nullable: false));
            DropColumn("dbo.Athlete", "RaceLevel");
        }
    }
}
