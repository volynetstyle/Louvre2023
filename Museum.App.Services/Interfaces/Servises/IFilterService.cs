using Museum.App.ViewModels.FilterViewModels;

namespace Museum.App.Services.Interfaces.Servises
{
    public interface IFilterService
    {
        public IEnumerable<FilterSectionViewModel> GetGalleryObjectsAsFilterPage();
        public IEnumerable<SideBarCollection> GetSideBarCollections();
        public Task AddVote(VoteViewModel vote);
        public Task RemoveVote(VoteViewModel vote);
        public Task<bool> IsVoteExistForUser(int userId);

        public Task<int> GetLikeCount(int objectId);
        public Task<int> GetDislikeCount(int objectId);
        public Task<int> GetCommentsCount(int objectId);

    }
}
