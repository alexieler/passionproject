namespace Triathlon.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedTriathlonDbToFitness : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Race", "AthleteID", "dbo.Athlete");
            DropIndex("dbo.Race", new[] { "AthleteID" });
            CreateTable(
                "dbo.Fitness",
                c => new
                    {
                        AthleteID = c.Int(nullable: false),
                        FitnessGoal = c.Int(nullable: false),
                        FitnessLevel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AthleteID)
                .ForeignKey("dbo.Athlete", t => t.AthleteID)
                .Index(t => t.AthleteID);
            
            AddColumn("dbo.Athlete", "FitnessLevel", c => c.Int(nullable: false));
            AddColumn("dbo.Athlete", "FitnessGoal", c => c.Int(nullable: false));
            DropColumn("dbo.Athlete", "RaceLevel");
            DropTable("dbo.Race");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Race",
                c => new
                    {
                        AthleteID = c.Int(nullable: false),
                        RaceType = c.Int(nullable: false),
                        TriathlonLevel = c.Int(nullable: false),
                        GoalTime = c.String(),
                        StartTrainingDate = c.DateTime(nullable: false),
                        RaceDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.AthleteID);
            
            AddColumn("dbo.Athlete", "RaceLevel", c => c.Int(nullable: false));
            DropForeignKey("dbo.Fitness", "AthleteID", "dbo.Athlete");
            DropIndex("dbo.Fitness", new[] { "AthleteID" });
            DropColumn("dbo.Athlete", "FitnessGoal");
            DropColumn("dbo.Athlete", "FitnessLevel");
            DropTable("dbo.Fitness");
            CreateIndex("dbo.Race", "AthleteID");
            AddForeignKey("dbo.Race", "AthleteID", "dbo.Athlete", "AthleteID");
        }
    }
}
