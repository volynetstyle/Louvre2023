using Museum.App.ViewModels.GalleryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.Gallery
{
    public class GalleryObjectViewModel
    {
        public IEnumerable<AccordionViewModel>? AccordionSection { get; set; }
        public GalleryMainSection? GalleryMainSection { get; set; }
    }
}
