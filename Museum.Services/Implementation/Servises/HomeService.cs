using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.ViewModels.Home;
using System.Linq.Expressions;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Interfaces.Repositories;
using System.Collections;
using Museum.Models.TableModels;
using Museum.App.Services.Adapters;

namespace Museum.App.Services.Implementation.Services
{
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicService<Categories, CategoryAdapter> _CategoriesRepository;
        private readonly IBasicService<ImageDboModel, ImageDboAdapter> _ImageDboRepository;
        private readonly IHomeRepository _HomeRepository;

        public HomeService(IMapper Mapper,
                           IHomeRepository HomeRepository,
                           IBasicService<Categories, CategoryAdapter> CategoriesRepository,
                           IBasicService<ImageDboModel, ImageDboAdapter> ImageDboRepository)
        {
            _mapper = Mapper;
            _HomeRepository = HomeRepository;
            _CategoriesRepository = CategoriesRepository;
            _ImageDboRepository = ImageDboRepository;
        }

        public HomeViewModel ViewModel
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public IEnumerable<Section>? AlbumSection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section>? ExibitSection()
        {
            var Collection = _CategoriesRepository.GetAll();
            var list = new List<Section>();

            foreach (var item in Collection)
            {
                var tmp_Obj = _HomeRepository.GetGalleryObjectsByCategoryID(item.CategoryId);
                var tmp_CategoryItem = _mapper.Map<IEnumerable<SectionItem>>(tmp_Obj);

                list.Add(new Section
                {
                    CategoryName = item.CategoryName,
                    CategoryDescription = item.Description,
                    CategoryItem = tmp_CategoryItem
                });
            }
            return list;
        }

        public IEnumerable<GallerySection>? GallerySection()
        {
            return _ImageDboRepository
                .GetAll()
                .Select(x => new GallerySection
                {
                    Title = x.AdditionalInfo,
                    Url = x.ImageLoc
                });
        }
    }
}
