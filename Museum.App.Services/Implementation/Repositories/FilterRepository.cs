using Dapper;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Attributes;
using Museum.App.ViewModels.FilterViewModels;
using Museum.Models.FilterModels;
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

        public IEnumerable<CheckboxViewModel> GetFilterSideBarCollection(FilterSideBarParams _params)
        { 
            using var conn = new SqlConnection(_db);
            return conn.Query<CheckboxViewModel>(
                "GetFilterSideBarCollection", 
                new 
                {
                    tableName = _params.tableName,
                    tablePK = _params.tablePK,
                    GalleryObjectFK = _params.GalleryObjectFK ?? _params.tablePK,
                    labelName = _params.labelName
                }, 
                commandType: CommandType.StoredProcedure);

        }

        public IEnumerable<FilterSectionModel> GetGalleryObjectsAsFilterPage()
        {
            using var conn = new SqlConnection(_db);
            return conn.Query<FilterSectionModel>(
                "SELECT * FROM GetGalleryObjectsAsFilterPage");
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
