using Museum.App.Services.Adapters;
using Museum.App.ViewModels.Filter;
using Museum.App.ViewModels.FilterViewModels;
using Museum.App.ViewModels.Home;
using Museum.Models.FilterModels;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IFilterService
    {
        public IEnumerable<FilterSectionViewModel> GetGalleryObjectsAsFilterPage();
        public IEnumerable<SideBarCollection> GetSideBarCollections();

    }
}
