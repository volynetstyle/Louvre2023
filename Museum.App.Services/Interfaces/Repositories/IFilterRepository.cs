using Museum.App.ViewModels.FilterViewModels;
using Museum.Models.FilterModels;
using Museum.Models.HomeModels;

namespace Museum.App.Services.Implementation.Repositories
{
    public interface IFilterRepository
    {
        IEnumerable<SectionItemModel> GetGalleryObjectsByCollectionID(int collectionID);
        public Task<IEnumerable<SectionItemModel>> GetGalleryObjectsByCollectionIDAsync(int collectionID);
        public IEnumerable<FilterSectionModel> GetGalleryObjectsAsFilterPage();
        public IEnumerable<CheckboxViewModel> GetFilterSideBarCollection(FilterSideBarParams _params);
    }
}
