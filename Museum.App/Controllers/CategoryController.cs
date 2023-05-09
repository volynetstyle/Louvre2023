using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
