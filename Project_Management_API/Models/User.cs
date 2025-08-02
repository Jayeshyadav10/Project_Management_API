

namespace Project_Management_API.Models
{
    public class User
    {

        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserRole Role { get; set; }
        public DateTime CreatedAt { get; set; }

        public enum UserRole
        {
            None = 0,
            Admin,
            ProjectManager,
            Developer,
            Viewer
        }


    }
}
