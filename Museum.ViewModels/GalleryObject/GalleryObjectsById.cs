using Museum.App.Services.Adapters;

namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryObjectsById
    {
        public CategoryAdapter? categoryAdapter { get; set; }
        public ArtistAdapter? artistAdapter { get; set; }
        public GalleryAdapter? galleryAdapter { get; set; }
        public CollectionAdapter? collectionAdapter { get; set; }
        public MuseumAdapter? museumAdapter { get; set; }
        public CollectionPartAdapter? partAdapter { get; set; }
        public HistoryAdapter? historyAdapter { get; set; }
        public LiteratureAdapter? literatureAdapter { get; set;}
    }

}