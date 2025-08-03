using Project_Management_API.Models;
using System.ComponentModel.DataAnnotations;

namespace Project_Management_API.DTOs
{
    public class ProjectDTOs
    {
    }
    public class ProjectCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public string ProjectManagerId { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }

    public class ProjectUpdateDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string? Description { get; set; }

        [Required]
        public ProjectStatus Status { get; set; }
    }
    public class ProjectResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string ProjectManagerId { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
