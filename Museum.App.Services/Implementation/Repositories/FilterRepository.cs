using Dapper;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Attributes;
using Museum.Models.HomeModels;
using System.Data;

namespace Museum.App.Services.Implementation.Repositories
{
    [Repository]
    public class FilterRepository : IFilterRepository
    {
        private readonly string _db;

        public FilterRepository(string db)
        {
            _db = db;
        }

        public IEnumerable<SectionItemModel> GetGalleryObjectsByCollectionID(int collectionID)
        {
            using var conn = new SqlConnection(_db);
            return conn.Query<SectionItemModel>(
                "GetGalleryObjectsByCollectionID",
                new { CollectionID = collectionID },
                commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<SectionItemModel>> GetGalleryObjectsByCollectionIDAsync(int collectionID)
        {
            using var conn = new SqlConnection(_db);
            return await conn.QueryAsync<SectionItemModel>(
                "GetGalleryObjectsByCollectionID",
                new { CollectionID = collectionID },
                commandType: CommandType.StoredProcedure);
        }
    }
}
