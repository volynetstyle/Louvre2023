using Microsoft.AspNetCore.Mvc;
using System;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.Error;
using Museum.App.ViewModels.Home;
using System.Diagnostics;
using Microsoft.Owin;
using Museum.App.Behaviors;

namespace Museum.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService _homeService;
        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            _homeService = homeService;
        }

        public IActionResult Index()
        {
            return View(new HomeViewModel(_homeService.ExibitSection(),
                                          null, 
                                          _homeService.GallerySection()));
        }
  
        //[HttpPost]
        //public JsonResult SearchAction(string customerName)
        //{
        //    var searchItem = _homeService?.ExibitSection()?.Where(x => x.CategoryName.Contains(customerName));
        //    return Json(searchItem);
        //}

        public ActionResult ViewCategory(string searchString) 
        {
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return View("Index", new HomeViewModel(_homeService.ExibitSection(),
                                          null,
                                          _homeService.GallerySection()));
            }
            else
            {
                var searchItem = _homeService?.ExibitSection()?.Where(x => x.CategoryName.Contains(searchString));

                //if (Request.IsAjaxRequest()) 
                //    return PartialView(searchItem);

                return View("Index", new HomeViewModel(searchItem));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}