using Microsoft.EntityFrameworkCore;
using TimeTableProject.Entities;

namespace TimeTableProject.Data
{
    public class DataContext: DbContext
    {

        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<TimeTable> TimeTable { get; set; } 
        public DbSet<BatchDetails> BatchDetals { get; set; }
        public DbSet<TeacherDetails> TeacherDetails { get; set; }
        public DbSet<TimeDetails> TimeDetails { get; set; }
        public DbSet<Responses> Responses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
