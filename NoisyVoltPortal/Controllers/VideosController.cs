using Microsoft.AspNetCore.Mvc;

namespace NoisyVoltPortal.Controllers
{
    public class VideosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
