using Microsoft.AspNetCore.Mvc;

namespace Museum.App.Controllers
{
    public class ManageController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
