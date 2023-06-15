using Museum.App.ViewModels.AdminViewModels;
using System.Data;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IAdminRepository
    {
        public void CreateFullBackup();
        public void CreateIncrementalBackup();
        public void CreateDifferentialBackup();

        public dynamic GetTables(string tableName);
        public void Delete(string tableName, int id);
        public IEnumerable<string> GetTableNames();
        public AnalytiscSection? GetAnalytiscSection();
        public IEnumerable<LastPostViewModel?> GetLastPostViewModel();
        public IEnumerable<LatestUpdateViewModel?> GetLatestUpdateViewModel();
        public RatingStateViewModel? GetRatingStateViewModel();
        public IEnumerable<UsersViewModel?>? GetUsersViewModel();
    }
}
