using Microsoft.EntityFrameworkCore;
using Project_Management_API.Models;

namespace Project_Management_API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectTask> ProjectTasks { get; set; }
        public DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key for many-to-many
            modelBuilder.Entity<ProjectDeveloper>()
                .HasKey(pd => new { pd.ProjectId, pd.DeveloperId });

            // Reduce index size
            modelBuilder.Entity<Project>()
    .Property(p => p.Id)
    .HasMaxLength(100);
            modelBuilder.Entity<ProjectDeveloper>()
                .Property(pd => pd.ProjectId)
                .HasMaxLength(100);
            modelBuilder.Entity<User>()
                 .Property(u => u.Id)
                 .HasMaxLength(100);

            modelBuilder.Entity<ProjectDeveloper>()
                .Property(pd => pd.DeveloperId)
                .HasMaxLength(100);

           

            // ProjectDeveloper → Project
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Project)
                .WithMany(p => p.ProjectDevelopers)
                .HasForeignKey(pd => pd.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);  // OK to cascade from Project

            // ProjectDeveloper → Developer (User)
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Developer)
                .WithMany(u => u.ProjectDevelopers)
                .HasForeignKey(pd => pd.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict); // Avoid multiple cascade paths

            // Project → ProjectManager (User)
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent cascade loop

            // ProjectTask → AssignedTo (User)
            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.AssignedTo)
                .WithMany()
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull); // Optional: Set null on delete

            // ProjectTask → Project
            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade); // Allow cascading task deletes if project deleted
        }
    }

}
