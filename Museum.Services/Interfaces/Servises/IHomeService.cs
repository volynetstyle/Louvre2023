using Museum.App.Services.Abstractions;
using Museum.App.ViewModels.Home;


namespace Museum.App.Services.Interfaces.Servises
{
    public interface IHomeService
    {
        public IEnumerable<Section>? ExibitSection();
        public IEnumerable<Section>? AlbumSection();
        public IEnumerable<GallerySection>? GallerySection();
    }
}
