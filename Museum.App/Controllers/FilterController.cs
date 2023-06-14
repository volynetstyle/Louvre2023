using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Utilites;
using Museum.App.ViewModels.Filter;
using Museum.Models.TableModels;
using Museum.App.ViewModels.FilterViewModels;
using AutoMapper;

namespace Museum.App.Controllers
{
    public class FilterController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ILogger<FilterController> _logger;
        private readonly IFilterService _filterService;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        private const int pageSize = 3;

        public FilterController(IMapper mapper,
                                ILogger<FilterController> logger,
                                IFilterService filterService,
                                SignInManager<ApplicationUser> signInManager,
                                UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _logger = logger;
            _filterService = filterService;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Index(int page = 1)
        {
            var filterViewModel = new FilterViewModel
            {
                pageSize = pageSize,

                FilterSections = _filterService
                    .GetGalleryObjectsAsFilterPageAsync()
                    .Result.Pagination(page, pageSize),

                FilterSideBarCollection = _filterService
                    .GetSideBarCollections()
            };

            return View("Index", filterViewModel);
        }

        [HttpPost]
        public PartialViewResult Action(string filterItemTitle, string itemLabel, bool isChecked)
        {
            var allData = _filterService.GetGalleryObjectsAsFilterPageAsync().Result;

            if (isChecked)
            {
                var filteredData = allData.Where(filterItem => filterItem.Title == filterItemTitle);

                return PartialView("_single-post", new FilterViewModel
                {
                    pageSize = pageSize,
                    FilterSections = filteredData.Pagination(1, pageSize)
                });
            }
            else
            {
                // Выполнить другие действия для снятого чекбокса в указанной категории
                // Дополнительные действия с данными

                // Возвращайте частичное представление с обновленными данными
                return PartialView("_YourPartialView", allData);
            }
        }

        public PartialViewResult ApplyFilter(string filter)
        {
            //A-Z, Z-A, RatingAsc, RatingDesc
            var allData = _filterService.GetGalleryObjectsAsFilterPageAsync().Result;
            var sortingData = filter switch
            {
                "A-Z" => allData.OrderBy(d => d.Title),
                "Z-A" => allData.OrderByDescending(d => d.Title),
                "RatingAsc" => allData.OrderByDescending(d => d.LikeCount),
                "RatingDesc" => allData.OrderByDescending(d => d.DislikeCount),
                _ => allData
            };

            return PartialView("_single-post", new FilterViewModel 
            { 
                pageSize = pageSize, 
                FilterSections = sortingData.Pagination(1, pageSize) 
            });
        }

        public PartialViewResult ViewCategory(string searchString)
        {
            int page = 1;
            if (string.IsNullOrWhiteSpace(searchString))
            {
                return PartialView("_single-post", new FilterViewModel
                {
                    pageSize = pageSize,

                    FilterSections = _filterService
                        .GetGalleryObjectsAsFilterPageAsync()
                        .Result.Pagination(page, pageSize)
                });
            }
            else
            {
                return PartialView("_single-post", new FilterViewModel
                {
                    pageSize = pageSize,

                    FilterSections = _filterService
                        .SearchExibitSection(searchString)
                        .Pagination(page, pageSize)
                });
            }
        }

        public IActionResult Page(int page)
        {
            return Index(page);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(FilterViewModel viewModel)
        {
            return await ProcessVote(viewModel);
        }

        #region private section
        private async void GroupByKey()
        {

        }

        
        private async Task<IActionResult> ProcessVote(FilterViewModel viewModel)
        {
            if (_signInManager.IsSignedIn(User))
            {
                if (int.TryParse(_userManager.GetUserId(User), out int ApplicationUser_ID))
                {
                    bool IsVoteExistForUser = await _filterService.IsVoteExistForUserAsync(viewModel.VoteViewModel.Object_ID);

                    var voteViewModel = _mapper.Map<VoteViewModel>(viewModel);
                    voteViewModel.ApplicationUser_ID = ApplicationUser_ID;

                    if (!IsVoteExistForUser)
                    {
                        await _filterService.AddVoteAsync(voteViewModel);
                    }
                    else
                    {
                        // TODO:
                        await _filterService.RemoveVoteAsync(voteViewModel);
                    }
                }

                return Index();
            }

            return Ok();
        }

        private async Task<int> GetPageCountAsync()
        {
            var galleryObjects = await _filterService.GetGalleryObjectsAsFilterPageAsync();
            int totalCount = galleryObjects.Count();
            return totalCount / pageSize;
        }
        #endregion
    }
}