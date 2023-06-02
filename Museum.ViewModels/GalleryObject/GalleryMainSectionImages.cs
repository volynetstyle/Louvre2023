
namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryMainSectionImages
    {
        public GalleryMainSectionImages() { }

        public GalleryMainSectionImages(string? url, string? title)
        {
            Url = url;
            Title = title;
        }

        public string? Url { get; set; }
        public string? Title { get; set; }
    }
}