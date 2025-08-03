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

           
            modelBuilder.Entity<ProjectDeveloper>()
                .HasKey(pd => new { pd.ProjectId, pd.DeveloperId });

           
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

           

            
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Project)
                .WithMany(p => p.ProjectDevelopers)
                .HasForeignKey(pd => pd.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);  

            
            modelBuilder.Entity<ProjectDeveloper>()
                .HasOne(pd => pd.Developer)
                .WithMany(u => u.ProjectDevelopers)
                .HasForeignKey(pd => pd.DeveloperId)
                .OnDelete(DeleteBehavior.Restrict); 

           
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany()
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict); 

            
            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.AssignedTo)
                .WithMany()
                .HasForeignKey(t => t.AssignedToId)
                .OnDelete(DeleteBehavior.SetNull); 

            
            modelBuilder.Entity<ProjectTask>()
                .HasOne(t => t.Project)
                .WithMany(p => p.Tasks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
