using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryMainSection
    {
        public string? Url { get; set; }
        public string? Title { get; set; }
        public IEnumerable<GalleryUl>? GalleryMainSectionItems { get; set; }
    }
}