namespace Triathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedAthlete : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Athlete", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Athlete", "Status", c => c.Int(nullable: false));
        }
    }
}
