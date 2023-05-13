using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Museum.App.Services.Abstractions;
using Museum.Models;
using Museum.App.Services.Adapters;
using AutoMapper;
using Museum.App.Services.Implementation.Services;
using Museum.App.Services.Interfaces.Servises;

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

                services.AddScoped<IHomeService, HomeService>();
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IAboutService, AboutService>();
                services.AddScoped<IGalleryService, GalleryService>();

                services.AddScoped<Artists>(connectionString);
                services.AddScoped<Categories>(connectionString);
                services.AddScoped<CollectionModel>(connectionString);
                services.AddScoped<CollectionPartModel>(connectionString);
                services.AddScoped<DirectorModel>(connectionString);
                services.AddScoped<GalleryModel>(connectionString);
                services.AddScoped<GalleryObjectModel>(connectionString);
                services.AddScoped<HistoryModel>(connectionString);
                services.AddScoped<ImageDboModel>(connectionString);
                services.AddScoped<LevelModel>(connectionString);
                services.AddScoped<LiteratureModel>(connectionString);
                services.AddScoped<MuseumModel>(connectionString);
                services.AddScoped<OnDisplayNowModel>(connectionString);
                services.AddScoped<RatingModel>(connectionString);
                services.AddScoped<ThemeAlbumModel>(connectionString);
                services.AddScoped<UserModel>(connectionString);
                services.AddScoped<WingsFloorsModel>(connectionString);
                return services;
            }
            else
            {
                throw new ArgumentNullException($"The connection string \"{connectionString}\" is null or empty in {typeof(DALConfiguration)}.");
            }
        }

        public static IServiceCollection AddScoped<TModel>(this IServiceCollection services, string connnenctionString) 
            where TModel : class 
        {
            return services.AddScoped(typeof(IBasicRepository<TModel>), 
                                      provider => new BaseRepository<TModel>(connnenctionString));
        }  

        public static MapperConfiguration ConfigureMapper()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                //Main configuration 
                cfg.CreateMap<Artists, ArtistAdapter>().ReverseMap();
                cfg.CreateMap<Categories, CategoryAdapter>().ReverseMap();
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