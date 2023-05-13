using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.Models;
using Museum.App.ViewModels.Home;
using System.Linq.Expressions;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Interfaces.Repositories;
using System.Collections;

namespace Museum.App.Services.Implementation.Services
{
    public class HomeService : IHomeService
    {
        private readonly IMapper _mapper;
        private readonly IBasicRepository<GalleryObjectModel> _ExibitionRepository;
        private readonly IBasicRepository<CollectionModel> _CollectionRepository;
        private readonly IBasicRepository<CollectionPartModel> _CollectionPartRepository;
        private readonly IBasicRepository<Categories> _CategoriesRepository;
        private readonly IBasicRepository<ImageDboModel> _ImageDboRepository;
        private readonly IHomeRepository _HomeRepository;

        public HomeService(IMapper Mapper,
                           IHomeRepository HomeRepository,
                           IBasicRepository<GalleryObjectModel> ExibitionRepository,
                           IBasicRepository<CollectionModel> CollectionRepository,
                           IBasicRepository<CollectionPartModel> CollectionPartRepository,
                           IBasicRepository<Categories> CategoriesRepository,
                           IBasicRepository<ImageDboModel> ImageDboRepository)
        {
            _mapper = Mapper;
            _HomeRepository = HomeRepository;
            _ExibitionRepository = ExibitionRepository;
            _CollectionRepository = CollectionRepository;
            _CollectionPartRepository = CollectionPartRepository;
            _CategoriesRepository = CategoriesRepository;
            _ImageDboRepository = ImageDboRepository;
        }

        public HomeViewModel ViewModel
        {
            get => throw new NotImplementedException();
            set => throw new NotImplementedException();
        }

        public Section? AlbumSection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Section>? ExibitSection()
        {
            var Collection = _CategoriesRepository.GetAll();
            var list = new List<Section>();

            foreach (var item in Collection)
            {
                var tmp_Obj = _HomeRepository.GetGalleryObjectsByCollectionID(item.CategoryId);
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
