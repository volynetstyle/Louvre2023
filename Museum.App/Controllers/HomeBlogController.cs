using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class HomeBlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
