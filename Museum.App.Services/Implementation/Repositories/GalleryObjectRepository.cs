using Museum.App.Services.Interfaces.Repositories;
using Museum.App.ViewModels.GalleryObject;
using Museum.Models.GalleryObjectModels;
using Museum.App.Services.Attributes;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using Museum.Models.TableModels;

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

        public IEnumerable<DefinitionModel> GetLouvreObjectDetailsAsDefinitiong(int Object_ID)
        {
            return GetAllObjects<DefinitionModel>(Object_ID, "GetLouvreObjectDetailsAsDefinition");
        }

        public DescStringModel GetGalleryDecsAsString(int Object_ID)
        {
            return GetFromObject<DescStringModel>(Object_ID, "GetObjectDetailsAsString");
        }

        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID)
        {
            return GetFromObject<GalleryMainSectionImages>(Object_ID, "GetGalleryObjectImages");
        }

        public GalleryUlModel GetGalleryUl(int Object_ID)
        {
            return GetFromObject<GalleryUlModel>(Object_ID, "GetGalleryObjectDescByID");
        }

        public IEnumerable<Literatures> GetLiteratures(int Object_ID)
        {
            return GetAllObjects<Literatures>(Object_ID, "GetLouvreObjectLiteratures");
        }
        #region Helpers
        private T GetFromObject<T>(int Object_ID, string ProcedureName)
        {
            using var sql = new SqlConnection(_connection);
            return sql.QuerySingleOrDefault<T>(ProcedureName, new { ObjectID = Object_ID }, commandType: CommandType.StoredProcedure);
        }

        private IEnumerable<T> GetAllObjects<T>(int Object_ID, string ProcedureName)
        {
            using var sql = new SqlConnection(_connection);
            return sql.Query<T>(ProcedureName, new { ObjectID = Object_ID }, commandType: CommandType.StoredProcedure);
        }

        private async Task<T> GetFromObjectAsync<T>(int Object_ID, string ProcedureName)
        {
            using var sql = new SqlConnection(_connection);
            return await sql.QuerySingleOrDefaultAsync<T>(ProcedureName, new { ObjectID = Object_ID }, commandType: CommandType.StoredProcedure);
        }

        private async Task<IEnumerable<T>> GetAllObjectsAsync<T>(int Object_ID, string ProcedureName)
        {
            using var sql = new SqlConnection(_connection);
            return await sql.QueryAsync<T>(ProcedureName, new { ObjectID = Object_ID }, commandType: CommandType.StoredProcedure);
        }
        #endregion
    }
}
