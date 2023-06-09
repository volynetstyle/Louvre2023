using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.ViewModels.Home;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Interfaces.Repositories;
using Museum.Models.TableModels;
using Museum.App.Services.Attributes;
using Museum.Models.Adapters;

namespace Museum.App.Services.Implementation.Services
{
    [Service]
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Categories, CategoriesAdapter> _CategoriesRepository;
        private readonly IBasicService<Images, ImagesAdapter> _ImageDboRepository;
        private readonly IHomeRepository _HomeRepository;

        public HomeService(IMapper Mapper,
                           IHomeRepository HomeRepository,
                           IBasicService<Categories, CategoriesAdapter> CategoriesRepository,
                           IBasicService<Images, ImagesAdapter> ImageDboRepository)
        {
            _mapper = Mapper;
            _HomeRepository = HomeRepository;
            _CategoriesRepository = CategoriesRepository;
            _ImageDboRepository = ImageDboRepository;
        }

        public IEnumerable<Section>? AlbumSection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section>? ExibitSection()
        {
            return _CategoriesRepository.GetAll().Select(c => new Section
            {
                CategoryName = c.CategoryName,
                CategoryDescription = c.Description,
                CategoryItem = _mapper.Map<IEnumerable<SectionItem>>(_HomeRepository.GetGalleryObjectsByCategoryID(c.Category_ID))
            });
        }

        public IEnumerable<GallerySection>? GallerySection()
        {
            return _ImageDboRepository
                .GetAll()
                .Select(x => new GallerySection 
                { 
                    Additional_Info = x.Additional_Info, 
                    Image_Loc = x.Image_Loc 
                });
        }

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
    }
}
