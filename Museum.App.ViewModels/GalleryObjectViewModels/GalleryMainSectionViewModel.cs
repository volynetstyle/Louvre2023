
using Museum.App.ViewModels.GalleryObjectViewModels;
using Museum.Models.Adapters;
using Museum.Models.GalleryObjectModels;

namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryMainSectionViewModel
    {

        public GalleryMainSectionImages? galleryMainSectionImages { get; set; }
        public GalleryUlViewModel? GalleryMainSectionItems { get; set; }
        public string? Details { get; set; }
        public IEnumerable<DefinitonViewModel>? Definitions { get; set; }
        public IEnumerable<LiteraturesAdapter>? Literatures { get; set; }
    }
}