using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

//using Microsoft.Data.Sqlite;

namespace Habit_Tracker.Models
{
    public class Habit
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Weekly Goal")]
        [Required]
        [Range(1,7)]    
        public int WeeklyGoal { get; set; }
        [DisplayName("Current Count")]
        public int CurrentCount { get; set; }
        public bool IsGoalMet { get; set; }
        public DateTime NextReset { get; set; }
    }
}
