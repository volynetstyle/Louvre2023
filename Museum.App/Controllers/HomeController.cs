using Microsoft.AspNetCore.Mvc;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.ViewModels.Error;
using Museum.App.ViewModels.Home;
using Museum.Models;
using System.Diagnostics;

namespace Museum.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IBasicService<Artists, ArtistAdapter> _artistService;
        private readonly IBasicService<Artists, CategoryAdapter> _categoryService;


        public HomeController(ILogger<HomeController> logger, 
                              IBasicService<Artists, ArtistAdapter> artistService,
                              IBasicService<Artists, CategoryAdapter> categoryService)
        {
            _logger = logger;
            _artistService = artistService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var val = _artistService.GetAll();
            var val1 = _categoryService.GetAll();

            return View(new HomeViewModel { Add = "", Continue = "", Remove = ""});
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}