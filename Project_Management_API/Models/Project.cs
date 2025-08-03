using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project_Management_API.Models
{
    public enum ProjectStatus { NotStarted, InProgress, Completed, OnHold }

    public class Project
    {
        [Key]
        public String Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string ProjectManagerId { get; set; }
        public User ProjectManager { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        public ProjectStatus Status { get; set; }

        public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }
}
