using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.ViewModels.Home;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Interfaces.Repositories;
using Museum.Models.TableModels;
using Museum.App.Services.Adapters;
using Museum.App.Services.Attributes;

namespace Museum.App.Services.Implementation.Services
{
    [Service]
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Categories, CategoryAdapter> _CategoriesRepository;
        private readonly IBasicService<Images, ImageDboAdapter> _ImageDboRepository;
        private readonly IHomeRepository _HomeRepository;

        public HomeService(IMapper Mapper,
                           IHomeRepository HomeRepository,
                           IBasicService<Categories, CategoryAdapter> CategoriesRepository,
                           IBasicService<Images, ImageDboAdapter> ImageDboRepository)
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
    }
}
