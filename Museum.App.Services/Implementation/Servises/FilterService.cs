using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Attributes;
using Museum.App.Services.Implementation.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.Filter;
using Museum.App.ViewModels.FilterViewModels;
using Museum.App.ViewModels.Home;
using Museum.Models.TableModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Dommel.Json.JsonParsers;
using Museum.Models.Adapters;

namespace Museum.App.Services.Implementation.Servises
{
    [Service]
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Artists ,ArtistsAdapter> _artistService;
        private readonly IBasicService<Categories, CategoriesAdapter> _categoryService;
        private readonly IBasicService<Collections, CollectionsAdapter> _collectionService;
        private readonly IBasicService<Raitings, RaitingAdapter> _raitingService;
        private readonly IBasicService<Comments, CommentsAdapter> _commentsService;
        private readonly IBasicRepository<Raitings> _raitingRepo;
        private readonly IBasicRepository<Comments> _commentsRepo;
        private readonly IFilterRepository _filterRepository;

        public FilterService(IMapper mapper, 
                             IBasicService<Artists, ArtistsAdapter> artistService,
                             IBasicService<Categories, CategoriesAdapter> categoryService,
                             IBasicService<Collections, CollectionsAdapter> collectionService,
                             IBasicService<Raitings, RaitingAdapter> raitingService,
                             IBasicService<Comments, CommentsAdapter> commentsService,
                             IFilterRepository filterRepository,
                             IBasicRepository<Raitings> raitingRepo,
                             IBasicRepository<Comments> commentsRepo)
        {
            _mapper = mapper;
            _artistService = artistService;
            _categoryService = categoryService;
            _collectionService = collectionService;
            _raitingService = raitingService;
            _commentsService = commentsService;
            _filterRepository = filterRepository;
            _raitingRepo = raitingRepo;
            _commentsRepo = commentsRepo;
        }

        public IEnumerable<ArtistsAdapter> GetArtists() 
            => _artistService.GetAll();

        public IEnumerable<CategoriesAdapter> GetCategories() 
            => _categoryService.GetAll();

        public IEnumerable<CollectionsAdapter> GetDepartmens() 
            => _collectionService.GetAll();

        public async Task<IEnumerable<FilterSectionViewModel>> GetGalleryObjectsAsFilterPageAsync()
        {
            List<FilterSectionViewModel> filterSections = new();

            foreach (var item in await _filterRepository.GetGalleryObjectsAsFilterPageAsync())
            {
                var tmp = _mapper.Map<FilterSectionViewModel>(item);

                tmp.LikeCount = await GetLikeCountAsync(tmp.OBJECT_ID);
                tmp.DislikeCount = await GetDislikeCountAsync(tmp.OBJECT_ID);
                tmp.CommentsCount = await GetCommentsCountAsync(tmp.OBJECT_ID);

                filterSections.Add(tmp);
            }

            return filterSections;
        }

        public async Task AddVoteAsync(VoteViewModel voteView) 
            => await _raitingService.AddAsync(_mapper.Map<RaitingAdapter>(voteView));

        public async Task RemoveVoteAsync(VoteViewModel vote) 
            => await _raitingService.DeleteAsync(_mapper.Map<RaitingAdapter>(vote));

        public async Task<bool> IsVoteExistForUserAsync(int userId) 
            => await _raitingRepo.AnyAsync(x => x.Object_ID == userId);

        public async Task<int> GetLikeCountAsync(int objectId) =>
            await _raitingRepo.CountByAsync(x => x.Object_ID == objectId && x.Rating > 0);

        public async Task<int> GetDislikeCountAsync(int objectId) =>
            await _raitingRepo.CountByAsync(x => x.Object_ID == objectId && x.Rating < 0);

        /// <summary>
        ///  TODO: This is the wrong implementation of comment counter for single post, update it
        /// </summary>
        /// <returns></returns>
        public async Task<int> GetCommentsCountAsync(int objectId) =>
            await _commentsService.CountAsync();

        public IEnumerable<SideBarCollection> GetSideBarCollections()
        {
            List<FilterSideBarParams> items= new List<FilterSideBarParams>
            {
                new FilterSideBarParams
                {
                    tableName = "Collections",
                    labelName = "department",
                    tablePK = "Collection_ID",
                    GalleryObjectFK = "Collection_ID"
                },
                new FilterSideBarParams
                {
                    tableName = "Artists",
                    labelName = "FullName",
                    tablePK = "Artist_ID",
                    GalleryObjectFK = "Artist_ID"
                },
                new FilterSideBarParams
                {
                    tableName = "Categories",
                    labelName = "CategoryName",
                    tablePK = "Category_ID",
                    GalleryObjectFK = "Category_ID"
                },
                new FilterSideBarParams
                {
                    tableName = "CollectionParts",
                    labelName = "PartName",
                    tablePK = "Part_ID",
                    GalleryObjectFK = "Collection_ID"
                }
            }; 

            if (items != null)
            {
                List<SideBarCollection> sideBars = new();

                foreach (var item in items)
                {
                    sideBars.Add(new SideBarCollection
                    {
                        Title = item.tableName,
                        Collection = _filterRepository.GetFilterSideBarCollection(item)
                    });
                }
                return sideBars;
            }
            return Enumerable.Empty<SideBarCollection>();
        }
    }
}
