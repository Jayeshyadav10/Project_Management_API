namespace Project_Management_API.Models
{
    public class ProjectDeveloper
    {
        public string ProjectId { get; set; }
        public Project Project { get; set; }

        public string DeveloperId { get; set; }
        public User Developer { get; set; }
    }
}
