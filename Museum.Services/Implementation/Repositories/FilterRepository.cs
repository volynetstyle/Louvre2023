using Dapper;
using Microsoft.Data.SqlClient;
using Museum.Models.FilterModels;
using Museum.Models.HomeModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Implementation.Repositories
{
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
            return conn.Query<SectionItemModel>("GetGalleryObjectsByCollectionID",
                new { CollectionID = collectionID },
                commandType: CommandType.StoredProcedure);
        }
    }
}
