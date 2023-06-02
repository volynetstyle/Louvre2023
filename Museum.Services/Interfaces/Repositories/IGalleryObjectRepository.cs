using Museum.App.ViewModels.GalleryObject;
using Museum.Models.TableModels;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IGalleryObjectRepository
    {
        public GalleryMainSectionImages GetGalleryObjectImages(int id);
        public Categories SingleCategory(int id);
    }
}
