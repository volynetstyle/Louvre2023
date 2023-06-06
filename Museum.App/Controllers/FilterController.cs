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
            var DepartmentCollection = _filterService.GetDepartmentSection();

            var filterViewModel = new FilterViewModel(null, DepartmentCollection, null, null, null, null);

            return View("Index", filterViewModel);
        }

        public IActionResult Filter(FilterViewModel viewModel)
        {
            var DepartmentCollection = _filterService.GetDepartmentSection();

            var filterViewModel = new FilterViewModel(null, DepartmentCollection, null, null,null,null);

            return View("Index", filterViewModel);
        }
    }
}
