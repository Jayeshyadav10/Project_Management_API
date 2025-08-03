using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project_Management_API.Data;
using Project_Management_API.DTOs;
using Project_Management_API.Models;

namespace Project_Management_API.Controllers
{
    [ApiController]
    [Route("api/projects/{projectId}/tasks")]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks(string projectId)
        {
            var tasks = await _context.ProjectTasks
                .Where(t => t.ProjectId == projectId)
                .Select(t => new TaskResponseDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    Status = t.Status,
                    AssignedToId = t.AssignedToId,
                    CreatedAt = t.CreatedAt,
                    DueDate = t.DueDate
                }).ToListAsync();

            return Ok(tasks);
        }

        [HttpPost]
        [Authorize(Roles = "Admin,ProjectManager,Developer")]
        public async Task<IActionResult> CreateTask(string projectId, TaskCreateDto dto)
        {
            var task = new ProjectTask
            {
                Id = Guid.NewGuid().ToString(),
                ProjectId = projectId,
                Title = dto.Title,
                Description = dto.Description,
                Status = dto.Status,
                AssignedToId = dto.AssignedToId,
                CreatedAt = DateTime.UtcNow,
                DueDate = dto.DueDate
            };

            _context.ProjectTasks.Add(task);
            await _context.SaveChangesAsync();

            return Ok(new { task.Id });
        }

        [HttpPut("/api/tasks/{taskId}")]
        [Authorize(Roles = "Admin,ProjectManager,Developer")]
        public async Task<IActionResult> UpdateTask(string taskId, TaskUpdateDto dto)
        {
            var task = await _context.ProjectTasks.FindAsync(taskId);
            if (task == null) return NotFound();

            task.Title = dto.Title;
            task.Description = dto.Description;
            task.Status = dto.Status;
            task.AssignedToId = dto.AssignedToId;
            task.DueDate = dto.DueDate;

            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("/api/tasks/{taskId}")]
        [Authorize(Roles = "Admin,ProjectManager")]
        public async Task<IActionResult> DeleteTask(string taskId)
        {
            var task = await _context.ProjectTasks.FindAsync(taskId);
            if (task == null) return NotFound();

            _context.ProjectTasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }


}
