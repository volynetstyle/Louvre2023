using AutoMapper;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Adapters;
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
    public class GalleryObjectService : IGalleryObjectService
    {
        public readonly IMapper _mapper;
        public readonly IBasicService<GalleryObjectModel, GalleryObjectAdapter> _serviceGallleryObject;


        public GalleryObjectService(IMapper mapper, 
                                    IBasicService<GalleryObjectModel, GalleryObjectAdapter> serviceGallleryObject)
        {
            _mapper = mapper;
            _serviceGallleryObject = serviceGallleryObject;
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
            throw new NotImplementedException();
        }
    }
}
