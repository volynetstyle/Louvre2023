using Dapper;
using System.Data;
using Museum.App.ViewModels.Home;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Interfaces.Repositories;
using Museum.Models.HomeModels;

namespace Museum.App.Services.Implementation.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly string _db;

        public HomeRepository(string db)
        {
            _db = db;
        }

        public IEnumerable<SectionItemModel> GetGalleryObjectsByCollectionID(int collectionID)
        {
            using var conn = new SqlConnection(_db); 
            return conn.Query<SectionItem>("GetGalleryObjectsByCollectionID", 
                new { CollectionID = collectionID }, 
                commandType: CommandType.StoredProcedure);
        }
    }
}
