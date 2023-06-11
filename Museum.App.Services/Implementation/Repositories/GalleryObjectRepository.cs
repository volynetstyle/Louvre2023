using Museum.App.Services.Interfaces.Repositories;
using Museum.App.ViewModels.GalleryObject;
using Museum.Models.GalleryObjectModels;
using Museum.App.Services.Attributes;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;

namespace Museum.App.Services.Implementation.Repositories
{
    [Repository]
    public class GalleryObjectRepository : IGalleryObjectRepository
    {
        private readonly string? _connection;

        public GalleryObjectRepository(string connection)
        {
            _connection = connection;
        }

        public string GetGalleryDecsAsString(int Object_ID)
        {
            return GetFromObject<string>(Object_ID, "GetObjectDetailsAsString");
        }

        public ObjectDetailsModel GetGalleryDecsAsTable(int Object_ID)
        {
            return GetFromObject<ObjectDetailsModel>(Object_ID, "GetObjectDetailsAsModel");
        }

        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID)
        {
            return GetFromObject<GalleryMainSectionImages>(Object_ID, "GetGalleryObjectImages");
        }

        public GalleryUlModel GetGalleryUl(int Object_ID)
        {
            return GetFromObject<GalleryUlModel>(Object_ID, "GetGalleryObjectDescByID");
        }

        private T GetFromObject<T>(int Object_ID, string ProcedureName)
        {
            using var sql = new SqlConnection(_connection);
            return sql.QuerySingleOrDefault<T>(ProcedureName, new { ObjectID = Object_ID }, commandType: CommandType.StoredProcedure);
        }
    }
}
