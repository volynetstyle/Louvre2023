using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Museum.App.Services.Abstractions;
using Museum.Models;
using Museum.App.Services.Adapters;
using AutoMapper;

namespace Museum.App.Adapters.DALConfiguration
{
    public static class DALConfiguration
    {
        public static IServiceCollection ConfigureDALServices(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString("MSSQL_Database");

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddSingleton(configuration);
                services.AddScoped(typeof(IBasicService<,>), typeof(BaseService<,>));
                services.AddScoped(typeof(IBasicRepository<>), typeof(BaseRepository<>));
                services.AddScoped(provider => new BaseRepository(connectionString));
                return services;
            }
            else
            {
                throw new ArgumentNullException($"The connection string \"{connectionString}\" is null or empty in {typeof(DALConfiguration)}.");
            }
        }

        public static MapperConfiguration ConfigureMapper()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                //Main configuration 
                cfg.CreateMap<ArtistModel, ArtistAdapter>().ReverseMap();
                cfg.CreateMap<CategoryModel, CategoryAdapter>().ReverseMap();
                cfg.CreateMap<CollectionModel, CollectionAdapter>().ReverseMap();
                cfg.CreateMap<CollectionPartModel, CollectionPartAdapter>().ReverseMap();
                cfg.CreateMap<DirectorModel, DirectorAdapter>().ReverseMap();
                cfg.CreateMap<GalleryModel, GalleryAdapter>().ReverseMap();
                cfg.CreateMap<GalleryObjectModel, GalleryObjectAdapter>().ReverseMap();
                cfg.CreateMap<HistoryModel, HistoryAdapter>().ReverseMap();
                cfg.CreateMap<ImageDboModel, ImageDboAdapter>().ReverseMap();
                cfg.CreateMap<LevelModel, LevelAdapter>().ReverseMap();
                cfg.CreateMap<LiteratureModel, LiteratureAdapter>().ReverseMap();
                cfg.CreateMap<MuseumModel, MuseumAdapter>().ReverseMap();
                cfg.CreateMap<OnDisplayNowModel, OnDisplayNowAdapter>().ReverseMap();
                cfg.CreateMap<RatingModel, RatingAdapter>().ReverseMap();
                cfg.CreateMap<ThemeAlbumModel, ThemeAlbumAdapter>().ReverseMap();
                cfg.CreateMap<UserModel, UserAdapter>().ReverseMap();
                cfg.CreateMap<WingsFloorsModel, WingsFloorsAdapter>().ReverseMap();

                //Another one ... like New...Adapter
            });

            mapperConfiguration.CreateMapper();
            return mapperConfiguration;
        }
    }
}