using Museum.App.ViewModels.FilterViewModels;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IFilterService
    {
        public IEnumerable<SideBarCollection> GetSideBarCollections();

        public Task<IEnumerable<FilterSectionViewModel>> GetGalleryObjectsAsFilterPageAsync();

        public Task AddVoteAsync(VoteViewModel vote);
        public Task RemoveVoteAsync(VoteViewModel vote);
        public Task<bool> IsVoteExistForUserAsync(int userId);

        public Task<int> GetLikeCountAsync(int objectId);
        public Task<int> GetDislikeCountAsync(int objectId);
        public Task<int> GetCommentsCountAsync(int objectId);

    }
}
