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

        public IActionResult Page(int page)
        {
            return Index(page);
        }

        [HttpPost]
        public async Task<IActionResult> Vote(FilterViewModel viewModel)
        {
            return await ProcessVote(viewModel);
        }

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
    }
}