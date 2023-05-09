using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class SingleBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
