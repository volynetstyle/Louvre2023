using Microsoft.AspNetCore.Mvc;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.Filter;

namespace Museum.App.Controllers
{
    public class FilterController : Controller
    {
        private readonly ILogger<FilterController> _logger;
        private readonly IFilterService _filterService;

        public FilterController(ILogger<FilterController> logger, IFilterService filterService)
        {
            _logger = logger;
            _filterService = filterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult Filter(FilterViewModel viewModel)
        //{
        //    var DepartmentCollection = _filterService.DepartmentFilter(viewModel.DepartmentCollection);
        //    var CategoryCollection = _filterService.CategoryFilter(viewModel.CategoryCollection);
        //    var ArtistCollection = _filterService.ArtistFilter(viewModel.ArtistCollection);

        //    var filterViewModel = new FilterViewModel(DepartmentCollection, CategoryCollection, ArtistCollection);

        //    return View("FilterPage", filterViewModel);
        //} 
    }
}
