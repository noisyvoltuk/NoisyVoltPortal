using Microsoft.AspNetCore.Mvc;

namespace NoisyVoltPortal.Controllers
{
    public class ProjectsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
