using System.ComponentModel.DataAnnotations;

namespace Project_Management_API.Models
{
    public enum TaskStatuses { Todo, InProgress, Done }

    public class ProjectTask
    {
        [Key]
        public string Id { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string ProjectId { get; set; }
        public Project Project { get; set; }

        public string? AssignedToId { get; set; }
        public User? AssignedTo { get; set; }

        [Required]
        public TaskStatuses Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? DueDate { get; set; }
    }
}
