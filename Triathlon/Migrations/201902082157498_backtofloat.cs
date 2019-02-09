namespace Triathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class backtofloat : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Workout", "WorkoutDistance", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Workout", "WorkoutDistance", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
