using Museum.App.ViewModels.GalleryObject;
using Museum.Models.Enums;
using Museum.Models.GalleryObjectModels;
using Museum.Models.TableModels;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IGalleryObjectRepository
    {
        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID);
        public GalleryUlModel GetGalleryUl(int Object_ID);
        public ObjectDetailsModel GetGalleryDecsAsTable(int Object_ID);
        public string GetGalleryDecsAsString(int Object_ID);

    }
}
