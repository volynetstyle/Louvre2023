using Museum.App.Services.Abstractions;
using Museum.App.ViewModels.Home;


namespace Museum.App.Services.Interfaces.Servises
{
    public interface IHomeService
    {
        public HomeViewModel ViewModel { get; set; }
        public IEnumerable<Section>? ExibitSection();
        public IEnumerable<Section>? AlbumSection();
        public IEnumerable<GallerySection>? GallerySection();
    }
}
