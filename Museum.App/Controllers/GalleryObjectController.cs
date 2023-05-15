using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class GalleryObjectController : Controller
    {
        private readonly ILogger<GalleryObjectController> _logger;

        public GalleryObjectController(ILogger<GalleryObjectController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
