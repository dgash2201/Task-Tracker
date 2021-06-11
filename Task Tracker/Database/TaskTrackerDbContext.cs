using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Task_Tracker.Entities;

namespace Task_Tracker
{
    public class TaskTrackerDbContext : DbContext
    {
        public TaskTrackerDbContext([NotNull] DbContextOptions options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }

        public DbSet<ProjectTask> Tasks { get; set; }
    }
}
