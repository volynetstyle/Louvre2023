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
        private readonly IBasicService<GalleryObjectModel, GalleryObjectAdapter> _serviceGallleryObject;
        private readonly IGalleryObjectRepository _galleryObjectRepository;

        public GalleryObjectService(IMapper mapper, 
                                    IBasicService<GalleryObjectModel, GalleryObjectAdapter> serviceGallleryObject
                                    IGalleryObjectRepository galleryObjectRepository)
        {
            _mapper = mapper;
            _serviceGallleryObject = serviceGallleryObject;
            _galleryObjectRepository = galleryObjectRepository;
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
                galleryMainSectionImages = _galleryObjectRepository.GetGalleryObjectImages(1),
                GalleryMainSectionItems 
                
            }
        }

        public bool IsObjectExist(int id)
        {
            return _serviceGallleryObject.Any(x => x.GalleryID == id);
        }
    }
}
