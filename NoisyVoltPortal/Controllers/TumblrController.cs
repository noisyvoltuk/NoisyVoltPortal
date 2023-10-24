using Microsoft.AspNetCore.Mvc;

namespace NoisyVoltPortal.Controllers
{
    public class TumblrController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
