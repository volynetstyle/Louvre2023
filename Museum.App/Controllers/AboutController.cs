using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
