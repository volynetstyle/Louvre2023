using Microsoft.AspNetCore.Mvc;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Utilites;
using Museum.App.ViewModels.Filter;
namespace Museum.App.Controllers
{
    public class FilterController : Controller
    {
        private readonly ILogger<FilterController> _logger;
        private readonly IFilterService _filterService;

        private const int pageSize = 3;

        public FilterController(ILogger<FilterController> logger, IFilterService filterService)
        {
            _logger = logger;
            _filterService = filterService;
        }

        public int PageCount => _filterService.GetGalleryObjectsAsFilterPage().Count() / pageSize;

        public IActionResult Index(int page = 1)
        {
            var filterViewModel = new FilterViewModel
            {
                pageSize = pageSize,

                FilterSections = _filterService
                    .GetGalleryObjectsAsFilterPage()
                    .Pagination(page, pageSize),

                FilterSideBarCollection = _filterService
                    .GetSideBarCollections()
            };

            return View("Index", filterViewModel);
        }


        public IActionResult Page(int page)
        {
            return Index(page);
        }
    }
}