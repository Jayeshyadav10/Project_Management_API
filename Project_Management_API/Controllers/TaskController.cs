using Microsoft.AspNetCore.Mvc;

namespace Project_Management_API.Controllers
{
    public class TaskController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
