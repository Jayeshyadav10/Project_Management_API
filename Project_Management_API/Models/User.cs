

using System.ComponentModel.DataAnnotations;

namespace Project_Management_API.Models
{
    public enum UserRole { Admin, ProjectManager, Developer, Viewer }

    public class User
    {
        [Key]
        public string Id { get; set; }

        [Required, MaxLength(50)]
        public string Username { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; }

        [Required]
        public UserRole Role { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
    }
}
