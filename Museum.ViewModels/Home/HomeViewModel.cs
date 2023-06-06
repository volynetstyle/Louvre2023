namespace Museum.App.ViewModels.Home;

public class HomeViewModel
{
    public HomeViewModel() { }

    public HomeViewModel(IEnumerable<Section>? exibitSection)
    {
        ExibitSection = exibitSection;
    }

    public HomeViewModel(IEnumerable<Section>? exibitSection, 
                         IEnumerable<Section>? albumSection, 
                         IEnumerable<GallerySection>? gallerySection)
        : this(exibitSection)
    {
        AlbumSection = albumSection;
        GallerySection = gallerySection;
    }

    public HomeViewModel(string? title, 
                         string? description, 
                         IEnumerable<Section>? exibitSection, 
                         IEnumerable<Section>? albumSection,
                         IEnumerable<GallerySection>? gallerySection)
        : this(exibitSection, albumSection, gallerySection)
    {
        Title = title;
        Description = description;
    }

    public string? Title { get; set; }
    public string? Description { get; set; }
    public IEnumerable<Section>? ExibitSection { get; set; }
    public IEnumerable<Section>? AlbumSection { get; set; }
    public IEnumerable<GallerySection>? GallerySection { get; set; }
}
