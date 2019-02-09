using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Triathlon.Models
{
    public enum Gender
    {
        Woman,
        Man,
        Trans,
        NonBinary,
        Private
    }

    public enum Status
    {
        Private,
        Public
    }

    public class Athlete
    {
        public int AthleteID { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]{1,50}$",
        ErrorMessage = "Sorry, your first name cannot be longer than 50 characters and can only contain characters.")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]{1,60}$",
        ErrorMessage = "Sorry, your first name cannot be longer than 60 characters and can only contain characters.")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Creation of Profile")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Level of Fitness")]
        public FitnessLevel FitnessLevel { get; set; }
        [Display(Name = "Overall Goal")]
        public FitnessGoal FitnessGoal { get; set; }

        /*how to get workouts and triathlon types
         * one athlete, one goal
         * one athlete, many workouts*/
        public virtual Fitness Fitness { get; set; } 
        public ICollection<Workout> Workouts { get; set; }
        /*public virtual Triathlon TriathlonType { get; set; }*/
    }
}