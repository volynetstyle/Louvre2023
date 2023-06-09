using Museum.App.ViewModels.FilterViewModels;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IFilterService
    {
        public IEnumerable<FilterSectionViewModel> GetGalleryObjectsAsFilterPage();
        public IEnumerable<SideBarCollection> GetSideBarCollections();

    }
}
