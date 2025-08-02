using Microsoft.EntityFrameworkCore;
using Project_Management_API.Models;

namespace Project_Management_API.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
       public DbSet<User> Users { get; set; }         
       public DbSet<Project> Project { get; set; }         
       public DbSet<ProjectTask> Task { get; set; }         
        
    }
}
