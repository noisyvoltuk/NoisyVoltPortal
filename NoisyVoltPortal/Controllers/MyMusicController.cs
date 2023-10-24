using Microsoft.AspNetCore.Mvc;

namespace NoisyVoltPortal.Controllers
{
    public class MyMusicController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
