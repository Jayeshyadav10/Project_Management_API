using Project_Management_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_Management_API.DTOs
{
    public class TaskDTO
    {
    }
    public class TaskCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public string? AssignedToId { get; set; }

        public TaskStatuses Status { get; set; } = TaskStatuses.Todo;

        public DateTime? DueDate { get; set; }
    }

    public class TaskUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskStatuses Status { get; set; }

        public string? AssignedToId { get; set; }

        public DateTime? DueDate { get; set; }
    }

    public class TaskResponseDto
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public TaskStatuses Status { get; set; }
        public string? AssignedToId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? DueDate { get; set; }
    }
}
