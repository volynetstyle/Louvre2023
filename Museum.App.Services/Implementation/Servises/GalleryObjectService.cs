using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Attributes;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.GalleryObject;
using Museum.App.ViewModels.GalleryObjectViewModels;
using Museum.Models.Adapters;
using Museum.Models.TableModels;


namespace Museum.App.Services.Implementation.Services
{
    [Service]
    public class GalleryObjectService  : IGalleryObjectService
    {
        private readonly IMapper _mapper;
        private readonly IGalleryObjectRepository _galleryObjectRepository;

        private readonly IBasicService<GalleryObjects, GalleryObjectsAdapter> _serviceGallleryObject;
        private readonly IBasicService<Categories, CategoriesAdapter> _categoryService;
        private readonly IBasicService<Artists, ArtistsAdapter> _artistService;
        private readonly IBasicService<LouvreMuseumGalleries, LouvreMuseumGalleriesAdapter> _galleryService;
        private readonly IBasicService<Collections, CollectionsAdapter> _collectionService;
        private readonly IBasicService<LouvreMuseumLevels, LouvreMuseumLevelsAdapter> _museumService;
        private readonly IBasicService<CollectionParts, CollectionPartsAdapter> _partService;
        private readonly IBasicService<Histories, HistoriesAdapter> _historyService;
        private readonly IBasicService<Literatures, LiteraturesAdapter> _literatureService;


        public GalleryObjectService(IMapper mapper,
                                    IGalleryObjectRepository galleryObjectRepository,
                                    IBasicService<GalleryObjects, GalleryObjectsAdapter> serviceGallleryObject,
                                    IBasicService<Categories, CategoriesAdapter> categoryService,
                                    IBasicService<Artists, ArtistsAdapter> artistService,
                                    IBasicService<LouvreMuseumGalleries, LouvreMuseumGalleriesAdapter> galleryService,
                                    IBasicService<Collections, CollectionsAdapter> collectionService,
                                    IBasicService<LouvreMuseumLevels, LouvreMuseumLevelsAdapter> museumService,
                                    IBasicService<CollectionParts, CollectionPartsAdapter> partService,
                                    IBasicService<Histories, HistoriesAdapter> historyService,
                                    IBasicService<Literatures, LiteraturesAdapter> literatureService
                                    )
        {
            _mapper = mapper;
            _serviceGallleryObject = serviceGallleryObject;
            _galleryObjectRepository = galleryObjectRepository;

            _categoryService = categoryService;
            _artistService = artistService;
            _galleryService= galleryService;
            _collectionService = collectionService;
            _museumService = museumService;
            _partService = partService;
            _historyService = historyService;
            _literatureService = literatureService;
        }

        public IEnumerable<AccordionViewModel>? AllAccordions()
        {
            throw new NotImplementedException();
        }

        public AccordionViewModel CreateSingleAccordion()
        {
            throw new NotImplementedException();
        }


        public GalleryMainSectionViewModel GetMainSection(int id)
        {
            return new GalleryMainSectionViewModel
            {
                galleryMainSectionImages = _galleryObjectRepository.GetGalleryObjectImages(id),
                GalleryMainSectionItems = _mapper.Map<GalleryUlViewModel>(_galleryObjectRepository.GetGalleryUl(id)),
                Details = _galleryObjectRepository.GetGalleryDecsAsString(id).Description,
                Definitions = _mapper.Map<IEnumerable<DefinitonViewModel>>(_galleryObjectRepository.GetLouvreObjectDetailsAsDefinitiong(id)),
                Literatures = _mapper.Map<IEnumerable<LiteraturesAdapter>>(_galleryObjectRepository.GetLiteratures(id))
            };
        }

        private GalleryObjectsByIdViewModel? GalleryObjectsById(int _id)
        {
            var id = _serviceGallleryObject.GetById(_id);

            return new GalleryObjectsByIdViewModel();
        }

        public bool IsObjectExist(int id)
        {
            return _serviceGallleryObject.Any(x => x.Gallery_ID == id);
        }

        public AccordionItemViewModel GetAccordionItem()
        {
            throw new NotImplementedException();
        }
    }
}
