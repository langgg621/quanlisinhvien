using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1.DbContexts
{
    public class ApplicationDbContexts:DbContext
    {
        public DbSet<Student> Students { get; set; }
        public int StudentId = 0;

        public DbSet<Subject> Subjects { get; set; }
        public int SubjectId = 0;
         
        public DbSet<Class> Classs { get; set; }
        public int ClassId = 0;
        public ApplicationDbContexts(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Class>()
                .HasOne<Student>()
                .WithMany()
                .HasForeignKey(e => e.StudentId);
            modelBuilder.Entity<Class>()
                .HasOne<Subject>()
                .WithMany()
                .HasForeignKey(e => e.SubjectId);
        }
    }
}
