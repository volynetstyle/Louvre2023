using Dapper;
using System.Data;
using Museum.App.ViewModels.Home;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Interfaces.Repositories;
using Museum.Models.HomeModels;
using Museum.App.Services.Attributes;

namespace Museum.App.Services.Implementation.Repositories
{
    [Repository]
    public class HomeRepository : IHomeRepository
    {
        private readonly string _db;

        public HomeRepository(string db)
        {
            _db = db;
        }

        public IEnumerable<SectionItemModel> GetGalleryObjectsByCategoryID(int categoryID)
        {
            using var conn = new SqlConnection(_db);
            var a = conn.Query<SectionItemModel>("GetGalleryObjectsByCategoryID",
                                                new { CategoryID = categoryID },
                                                commandType: CommandType.StoredProcedure);

            return a;
        }
    }
}
