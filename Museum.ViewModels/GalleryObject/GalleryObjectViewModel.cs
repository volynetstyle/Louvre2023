
namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryObjectViewModel
    {
        public GalleryMainSection? GalleryMainSection { get; set; }
        public GalleryObjectsById? GetObjectsById { get; set; }
        public IEnumerable<AccordionViewModel>? AccordionSection { get; set; }
    }
}
