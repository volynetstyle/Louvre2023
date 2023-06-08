
namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryMainSectionViewModel
    {
        public GalleryMainSectionViewModel() { }
        public GalleryMainSectionViewModel(GalleryMainSectionImages? galleryMainSectionImages, 
                                           GalleryUlViewModel galleryMainSectionItems)
        {
            this.galleryMainSectionImages = galleryMainSectionImages;
            GalleryMainSectionItems = galleryMainSectionItems;
        }

        public GalleryMainSectionImages? galleryMainSectionImages { get; set; }
        public GalleryUlViewModel? GalleryMainSectionItems { get; set; }
    }
}