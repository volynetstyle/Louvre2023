using Museum.App.Services.Adapters;
using Museum.App.ViewModels.Filter;
using Museum.App.ViewModels.Home;
using Museum.Models.FilterModels;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IFilterService
    {
        public IEnumerable<DepartmentSection>? GetDepartmentSection();
        public IEnumerable<DepartmentSection>? SearchAction(string? pattern = null);
        public IEnumerable<DepartmentSection>? Filter(FilterViewModel viewModel);
        public IEnumerable<CategoryAdapter> GetCategories();
        public IEnumerable<CollectionAdapter> GetDepartmens();
        public IEnumerable<ArtistAdapter> GetArtists();
    }
}
