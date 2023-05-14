using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Implementation.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.Filter;
using Museum.App.ViewModels.Home;
using Museum.Models.TableModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Implementation.Servises
{
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Artists ,ArtistAdapter> _artistService;
        private readonly IBasicService<Categories, CategoryAdapter> _categoryService;
        private readonly IBasicService<CollectionModel, CollectionAdapter> _collectionService;
        private readonly IFilterRepository _filterRepository;

        public FilterService(IMapper mapper, 
                             IBasicService<Artists, ArtistAdapter> artistService,
                             IBasicService<Categories, CategoryAdapter> categoryService,
                             IBasicService<CollectionModel, CollectionAdapter> collectionService,
                             IFilterRepository filterRepository)
        {
            _mapper = mapper;
            _artistService = artistService;
            _categoryService = categoryService;
            _collectionService = collectionService;
            _filterRepository = filterRepository;
        }

        public IEnumerable<DepartmentSection>? GetDepartmentSection()
        {
            var Collection = _collectionService.GetAll();
            var list = new List<DepartmentSection>();

            foreach (var item in Collection)
            {
                var tmp_Obj = _filterRepository.GetGalleryObjectsByCollectionID(item.CollectionId);
                var tmp_CategoryItem = _mapper.Map<IEnumerable<SectionItem>>(tmp_Obj);

                list.Add(new DepartmentSection { DepartmentName = item.Department, DepartmentItem = tmp_CategoryItem });
            }
            return list;
        }

        public IEnumerable<ArtistAdapter> GetArtists() => _artistService.GetAll();

        public IEnumerable<CategoryAdapter> GetCategories() => _categoryService.GetAll();

        public IEnumerable<CollectionAdapter> GetDepartmens() => _collectionService.GetAll();

        public IEnumerable<DepartmentSection>? SearchAction(string? pattern = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentSection>? Filter(FilterViewModel viewModel)
        {
            throw new NotImplementedException();
        }
    }
}
