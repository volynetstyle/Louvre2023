using Museum.App.Services.Attributes;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.ViewModels.GalleryObject;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using Museum.App.Services.Abstractions;
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

        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID)
        {
            using var sql = new SqlConnection(_connection);
            return sql.QuerySingleOrDefault<GalleryMainSectionImages>(
                "GetGalleryObjectImages", 
                new { ObjectID = Object_ID }, 
                commandType: CommandType.StoredProcedure);
        }

        public GalleryUlViewModel GetGalleryUl(int Object_ID)
        {
            using var sql = new SqlConnection(_connection);
            return sql.QuerySingleOrDefault<GalleryUlViewModel>(
                "GetGalleryObjectDescByID",
                new { ObjectID = Object_ID }, 
                commandType: CommandType.StoredProcedure);
        }
    }
}
