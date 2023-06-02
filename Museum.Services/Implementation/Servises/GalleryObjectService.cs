using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
using Museum.App.Services.Attributes;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.ViewModels.GalleryObject;
using Museum.Models.TableModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Implementation.Services
{
    [Service]
    public class GalleryObjectService : IGalleryObjectService
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

        public AccordionItem GetAccordionItem()
        {
            throw new NotImplementedException();
        }

        public GalleryMainSection GetMainSection()
        {
            return new GalleryMainSection
            {
                galleryMainSectionImages = _galleryObjectRepository.GetGalleryObjectImages(1)
            };
        }

        private void test()
        {
            var id = _serviceGallleryObject.GetById(1);
            var a = new GalleryObjectsById
            {
                categoryAdapter = id.CategoryID.HasValue ? _categoryService.GetById(id.CategoryID.Value) : null,
                
                artistAdapter = id.ArtistID.HasValue ? _artistService.GetById(id.ArtistID.Value) : null,
                
                galleryAdapter = id.GalleryID.HasValue ? _galleryService.GetById(id.GalleryID.Value) : null,
                
                collectionAdapter = id.CollectionID.HasValue ? _collectionService.GetById(id.CollectionID.Value) : null,
                
                museumAdapter = id.MuseamID.HasValue ? _museumService.GetById(id.MuseamID.Value) : null,
                
                partAdapter = id.PartID.HasValue ? _partService.GetById(id.PartID.Value) : null,
                
                historyAdapter = id.HistoryID.HasValue ? _historyService.GetById(id.HistoryID.Value) : null,
                
                literatureAdapter = id.LiteratureID.HasValue ? _literatureService.GetById(id.LiteratureID.Value) : null
            };
        }

        public bool IsObjectExist(int id)
        {
            return _serviceGallleryObject.Any(x => x.GalleryID == id);
        }
    }
}
