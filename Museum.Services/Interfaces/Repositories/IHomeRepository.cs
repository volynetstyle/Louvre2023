using Museum.App.ViewModels.Home;
using Museum.Models.HomeModels;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IHomeRepository
    {
        IEnumerable<SectionItemModel> GetGalleryObjectsByCollectionID(int collectionID);
    }
}
