using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Habit_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Habit_Tracker.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Habit> Habit { get; set; }
    }
}
