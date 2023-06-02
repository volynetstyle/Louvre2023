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
        private readonly IBasicRepository<Categories> _categoryRepository;
        private readonly IBasicRepository<Artists> _artistRepository;
        private readonly IBasicRepository<LouvreMuseumGalleries> _galleryRepository;
        private readonly IBasicRepository<Collections> _colletionRepository;
        private readonly IBasicRepository<Museams> _museumRepository;
        private readonly IBasicRepository<CollectionParts> _colletionPartsRepository;

        public GalleryObjectRepository(string connection,
                                       IBasicRepository<Categories> categoryRepository,
                                       IBasicRepository<Artists> artistRepository,
                                       IBasicRepository<LouvreMuseumGalleries> galleryRepository,
                                       IBasicRepository<Collections> colletionRepository,
                                       IBasicRepository<Museams> museumRepository,
                                       IBasicRepository<CollectionParts> colletionPartsRepository)
        {
            _connection = connection;
            _categoryRepository = categoryRepository;
            _artistRepository = artistRepository;
            _galleryRepository = galleryRepository;
            _colletionRepository = colletionRepository;
            _museumRepository = museumRepository;
            _colletionPartsRepository = colletionPartsRepository;
        }

        public GalleryMainSectionImages GetGalleryObjectImages(int Object_ID)
        {
            using var sql = new SqlConnection(_connection);
            return sql.QuerySingleOrDefault<GalleryMainSectionImages>("GetGalleryObjectImages", new {Object_ID = Object_ID}, commandType: CommandType.StoredProcedure);
        }

        public Categories SingleCategory(int id)
        {
            throw new NotImplementedException();
        }
    }
}
