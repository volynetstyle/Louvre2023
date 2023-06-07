using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Attributes;
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
    [Service]
    public class FilterService : IFilterService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Artists ,ArtistAdapter> _artistService;
        private readonly IBasicService<Categories, CategoryAdapter> _categoryService;
        private readonly IBasicService<Collections, CollectionAdapter> _collectionService;
        private readonly IFilterRepository _filterRepository;

        public FilterService(IMapper mapper, 
                             IBasicService<Artists, ArtistAdapter> artistService,
                             IBasicService<Categories, CategoryAdapter> categoryService,
                             IBasicService<Collections, CollectionAdapter> collectionService,
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
            return _collectionService.GetAll().Select(c => new DepartmentSection
            {
                DepartmentName = c.Department,
                DepartmentItem = _mapper.Map<IEnumerable<SectionItem>>(_filterRepository.GetGalleryObjectsByCollectionID(c.Collection_ID))
            });
        }

        public IEnumerable<ArtistAdapter> GetArtists() => _artistService.GetAll();

        public IEnumerable<CategoryAdapter> GetCategories() => _categoryService.GetAll();

        public IEnumerable<CollectionAdapter> GetDepartmens() => _collectionService.GetAll();

        public IEnumerable<Section> SearchExibitSection(string searchString)
        {
            var exibitSections = ExibitSection();

            if (exibitSections == null || string.IsNullOrEmpty(searchString))
            {
                return Enumerable.Empty<Section>();
            }
            else
            {
                var filteredSections = new List<Section>();

                foreach (var exibitSection in exibitSections)
                {
                    if (exibitSection != null && exibitSection.CategoryItem != null)
                    {
                        var filteredCategoryItems = exibitSection.CategoryItem
                            ?.Where(item => item?.Title?.Contains(searchString) == true)
                            .ToList();

                        if (filteredCategoryItems != null && filteredCategoryItems.Count != 0)
                        {
                            filteredSections.Add(new Section
                            {
                                CategoryName = exibitSection.CategoryName,
                                CategoryDescription = exibitSection.CategoryDescription,
                                CategoryItem = filteredCategoryItems
                            });
                        }
                    }
                }
                return filteredSections;
            }
        }
        public IEnumerable<DepartmentSection>? Filter(FilterViewModel viewModel)
        {
            var coll = GetDepartmens();

            //viewModel.DepartmentCollection.Selec)

            throw new NotImplementedException();
        }
    }
}
