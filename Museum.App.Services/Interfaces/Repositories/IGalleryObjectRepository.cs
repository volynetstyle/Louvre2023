using Museum.App.ViewModels.GalleryObject;
using Museum.Models.Enums;
using Museum.Models.GalleryObjectModels;
using Museum.Models.TableModels;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IGalleryObjectRepository
    {
        public IEnumerable<DefinitionModel> GetLouvreObjectDetailsAsDefinitiong(int Object_ID);
        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID);
        public GalleryUlModel GetGalleryUl(int Object_ID);
        public DescStringModel GetGalleryDecsAsString(int Object_ID);
        public IEnumerable<Literatures> GetLiteratures(int Object_ID);
    }
}
