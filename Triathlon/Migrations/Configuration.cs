namespace Triathlon.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Triathlon.Models;
    using Triathlon.DAL;

    internal sealed class Configuration : DbMigrationsConfiguration<Triathlon.DAL.RaceContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Triathlon.DAL.RaceContext context)
        {
            var athletes = new List<Athlete>
            {
                new Athlete{AthleteID=1,FirstName="Thomas",LastName="Leroux",Gender=Gender.Man,Email="thomasemail@gmail.com",DOB=DateTime.Parse("1965-09-24"),CreatedAt=DateTime.Parse("2019-01-29")},
                new Athlete{AthleteID=2,FirstName="Alexie",LastName="Frankley",Gender=Gender.Woman,Email="alexemail@gmail.com",DOB=DateTime.Parse("1995-06-11"),CreatedAt=DateTime.Parse("2019-01-27")},
                new Athlete{AthleteID=3,FirstName="Zack",LastName="Smith",Gender=Gender.Private,Email="123aunonymous@gmail.com",DOB=DateTime.Parse("1997-06-30"),CreatedAt=DateTime.Parse("2019-01-27")}
            };

            athletes.ForEach(s => context.Athletes.AddOrUpdate(p => p.LastName, s));
            context.SaveChanges();
            var workouts = new List<Workout>
            {
                new Workout{WorkoutID=1,AthleteID = athletes.Single(s => s.LastName == "Leroux").AthleteID,WorkoutDescription="This workout was super duper intense",WorkoutDate=DateTime.Parse("2019-01-29"),WorkoutDistance=5,WorkoutIntensity=WorkoutIntensity.Breezy,WorkoutCategory=WorkoutCategory.Bike},
                new Workout{WorkoutID=2,AthleteID = athletes.Single(s => s.LastName == "Leroux").AthleteID,WorkoutDescription="Will have to retry this soon",WorkoutDate=DateTime.Parse("2019-01-30"),WorkoutDistance=10,WorkoutIntensity=WorkoutIntensity.Exhaustion,WorkoutCategory=WorkoutCategory.Strength},
                new Workout{WorkoutID=3,AthleteID = athletes.Single(s => s.LastName == "Leroux").AthleteID,WorkoutDescription="It was really easy.",WorkoutDate=DateTime.Parse("2019-01-30"),WorkoutDistance=10,WorkoutIntensity=WorkoutIntensity.Exhaustion,WorkoutCategory=WorkoutCategory.Strength},
                new Workout{WorkoutID=4,AthleteID = athletes.Single(s => s.LastName == "Smith").AthleteID,WorkoutDescription="Too easy.",WorkoutDate=DateTime.Parse("2019-01-30"),WorkoutDistance=10,WorkoutIntensity=WorkoutIntensity.Exhaustion,WorkoutCategory=WorkoutCategory.Strength},
                new Workout{WorkoutID=5,AthleteID = athletes.Single(s => s.LastName == "Smith").AthleteID,WorkoutDescription="Too hard",WorkoutDate=DateTime.Parse("2019-01-30"),WorkoutDistance=15,WorkoutIntensity=WorkoutIntensity.Exhaustion,WorkoutCategory=WorkoutCategory.Strength}
            };

            foreach (Workout e in workouts)
            {
                var workoutInDataBase = context.Workouts.Where(
                s =>
                     s.Athlete.AthleteID == e.AthleteID).SingleOrDefault();
                if (workoutInDataBase == null)
                {
                    context.Workouts.Add(e);
                }
            }
            context.SaveChanges();

            /*workouts.ForEach(s => context.Workouts.Add(s));
            context.SaveChanges();*/

            var fitnesses = new List<Fitness>
            {
                new Fitness{AthleteID = athletes.Single(s => s.LastName == "Leroux").AthleteID,FitnessGoal=FitnessGoal.Flexibility,FitnessLevel=FitnessLevel.Beginner},
                new Fitness{AthleteID = athletes.Single(s => s.LastName == "Smith").AthleteID,FitnessGoal=FitnessGoal.Stamina,FitnessLevel=FitnessLevel.Advanced},
                new Fitness{AthleteID = athletes.Single(s => s.LastName == "Frankley").AthleteID,FitnessGoal=FitnessGoal.Weightloss,FitnessLevel=FitnessLevel.Beginner}
            };

            fitnesses.ForEach(s => context.Fitesses.AddOrUpdate(p => p.AthleteID, s));
            context.SaveChanges();

            /*races.ForEach(s => context.Races.Add(s));
            context.SaveChanges();*/
        }
    }
}
