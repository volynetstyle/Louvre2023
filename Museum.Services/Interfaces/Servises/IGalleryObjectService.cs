using Museum.App.ViewModels.GalleryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IGalleryObjectService
    {
        public GalleryMainSection GetMainSection();
        public AccordionItem GetAccordionItem();
        public AccordionViewModel CreateSingleAccordion();

    }
}
