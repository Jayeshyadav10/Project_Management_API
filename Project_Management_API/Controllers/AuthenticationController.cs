using Microsoft.AspNetCore.Mvc;

namespace Project_Management_API.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
