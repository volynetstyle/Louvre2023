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
        public bool IsObjectExist(int id);
        public AccordionViewModel CreateSingleAccordion();
        public AccordionItem GetAccordionItem();
        public GalleryMainSection GetMainSection();
        public IEnumerable<AccordionViewModel>? AllAccordions();
    }
}
