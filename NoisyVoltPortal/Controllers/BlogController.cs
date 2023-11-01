using Microsoft.AspNetCore.Mvc;
using NoisyVoltPortal.Services;


namespace NoisyVoltPortal.Controllers
{
    public class BlogController : Controller
    {
        private IContentDataService _contentDataService;


        public BlogController(IContentDataService contentDataService)
        {
            _contentDataService = contentDataService;
        }
        public IActionResult Index()
        {
            var tt = _contentDataService.GetBlogEntries();

            return View(tt);
        }
    }
}
