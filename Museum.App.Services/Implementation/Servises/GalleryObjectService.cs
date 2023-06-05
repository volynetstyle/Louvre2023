using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Attributes;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.GalleryObject;
using Museum.Models.TableModels;


namespace Museum.App.Services.Implementation.Services
{
    [Service]
    public class GalleryObjectService  : IGalleryObjectService
    {
        private readonly IMapper _mapper;
        private readonly IGalleryObjectRepository _galleryObjectRepository;

        private readonly IBasicService<GalleryObjects, GalleryObjectAdapter> _serviceGallleryObject;
        private readonly IBasicService<Categories, CategoryAdapter> _categoryService;
        private readonly IBasicService<Artists, ArtistAdapter> _artistService;
        private readonly IBasicService<LouvreMuseumGalleries, GalleryAdapter> _galleryService;
        private readonly IBasicService<Collections, CollectionAdapter> _collectionService;
        private readonly IBasicService<LouvreMuseumLevels, MuseumAdapter> _museumService;
        private readonly IBasicService<CollectionParts, CollectionPartAdapter> _partService;
        private readonly IBasicService<Histories, HistoryAdapter> _historyService;
        private readonly IBasicService<Literatures, LiteratureAdapter> _literatureService;


        public GalleryObjectService(IMapper mapper,
                                    IGalleryObjectRepository galleryObjectRepository,
                                    IBasicService<GalleryObjects, GalleryObjectAdapter> serviceGallleryObject,
                                    IBasicService<Categories, CategoryAdapter> categoryService,
                                    IBasicService<Artists, ArtistAdapter> artistService,
                                    IBasicService<LouvreMuseumGalleries, GalleryAdapter> galleryService,
                                    IBasicService<Collections, CollectionAdapter> collectionService,
                                    IBasicService<LouvreMuseumLevels, MuseumAdapter> museumService,
                                    IBasicService<CollectionParts, CollectionPartAdapter> partService,
                                    IBasicService<Histories, HistoryAdapter> historyService,
                                    IBasicService<Literatures, LiteratureAdapter> literatureService
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
                GalleryMainSectionItems = _galleryObjectRepository.GetGalleryUl(id)
            };
        }

        private GalleryObjectsByIdViewModel? GalleryObjectsById(int _id)
        {
            var id = _serviceGallleryObject.GetById(_id);
            
                return new GalleryObjectsByIdViewModel
                {
                    categoryAdapter = id.Category_ID.HasValue ? _categoryService.GetById(id.Category_ID.Value) : null,
                    artistAdapter = id.Artist_ID.HasValue ? _artistService.GetById(id.Artist_ID.Value) : null,
                    galleryAdapter = id.Gallery_ID.HasValue ? _galleryService.GetById(id.Gallery_ID.Value) : null,
                    collectionAdapter = id.Collection_ID.HasValue ? _collectionService.GetById(id.Collection_ID.Value) : null,
                    museumAdapter = id.Museam_ID.HasValue ? _museumService.GetById(id.Museam_ID.Value) : null,
                    partAdapter = id.Part_ID.HasValue ? _partService.GetById(id.Part_ID.Value) : null,
                    historyAdapter = id.History_ID.HasValue ? _historyService.GetById(id.History_ID.Value) : null,
                    literatureAdapter = id.LiteratureID.HasValue ? _literatureService.GetById(id.LiteratureID.Value) : null
                };
            
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
