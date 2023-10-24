using Microsoft.AspNetCore.Mvc;

namespace NoisyVoltPortal.Controllers
{
    public class HowToPlayController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
