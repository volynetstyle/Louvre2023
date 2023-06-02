
namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryObjectViewModel
    {
        public GalleryObjectViewModel() { }

        public GalleryObjectViewModel(GalleryMainSectionViewModel? galleryMainSection, GalleryObjectsByIdViewModel? getObjectsById, IEnumerable<AccordionViewModel>? accordionSection)
        {
            GalleryMainSection = galleryMainSection;
            GetObjectsById = getObjectsById;
            AccordionSection = accordionSection;
        }

        public GalleryMainSectionViewModel? GalleryMainSection { get; set; }
        public GalleryObjectsByIdViewModel? GetObjectsById { get; set; }
        public IEnumerable<AccordionViewModel>? AccordionSection { get; set; }
    }
}
