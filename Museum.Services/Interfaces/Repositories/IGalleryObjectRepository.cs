using Museum.App.ViewModels.GalleryObject;
using Museum.Models.TableModels;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IGalleryObjectRepository
    {
        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID);
        public GalleryUlViewModel GetGalleryUl(int Object_ID);
    }
}
