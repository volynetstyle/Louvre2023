using Microsoft.AspNetCore.Mvc;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.Models.TableModels;
using Museum.App.ViewModels.GalleryObject;

namespace Museum.App.Controllers
{
    public class GalleryObjectController : Controller
    {
        private readonly ILogger<GalleryObjectController> _logger;
        private readonly IGalleryObjectService _galleryObjectService;

        public GalleryObjectController(ILogger<GalleryObjectController> logger,
                                       IGalleryObjectService galleryObjectService
                                       )
        {
            _logger = logger;
            _galleryObjectService = galleryObjectService;
        }   

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/GalleryObject")]
        public IActionResult CatchObjectId(int Object_ID)
        {
            return View("Index", new GalleryObjectViewModel
            {
                GalleryMainSection = _galleryObjectService.GetMainSection(Object_ID)
            });
        }
    }
}
