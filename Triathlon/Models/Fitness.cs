using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Triathlon.Models
{
    public enum FitnessGoal
    {
        Weightloss,
        Strength,
        Flexibility,
        Stamina
    }

    public enum FitnessLevel
    {
        Beginner,
        Intermediate,
        Advanced
    }

    public class Fitness
    {
        [Key]
        [ForeignKey("Athlete")]
        public int AthleteID { get; set; }
        public FitnessGoal FitnessGoal { get; set; }
        public FitnessLevel FitnessLevel { get; set; }

        /* how to get the athlete */
        public virtual Athlete Athlete { get; set; }
        /*one athlete, one triathlon, one-to-one */
    }
}