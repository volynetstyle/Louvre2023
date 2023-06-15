using Museum.Models.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class EditViewModel
    {
        public IEnumerable<CategoriesAdapter>? categoriesAdapters { get; set; }
        public IEnumerable<ArtistsAdapter>? artistsAdapters { get; set; }
        public IEnumerable<LouvreMuseumGalleriesAdapter>? louvreMuseumGalleriesAdapters { get; set; }
        public IEnumerable<CollectionsAdapter>? collectionsAdapters { get; set; }
        public IEnumerable<MuseamsAdapter>? museamsAdapters { get; set; }
        public IEnumerable<CollectionPartsAdapter>? PartsAdapters { get; set; }
        public IEnumerable<GalleryObjectsAdapter>? galleryObjectsAdapters { get; set; }
    }
}
