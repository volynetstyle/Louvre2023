using Museum.App.Services.Adapters;
using AutoMapper;
using Museum.Models.HomeModels;
using Museum.App.ViewModels.Home;
using Museum.Models.TableModels;
using Museum.App.Services.Interfaces.Servises;
using Museum.App.Services.Implementation.Services;
using Museum.App.Services.Implementation.Repositories;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.Services.Implementation.Servises;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Implementation.Servises.Other;
using Museum.App.ViewModels.FilterViewModels;
using Museum.Models.FilterModels;

namespace Museum.App.Adapters.DALConfiguration
{
    public static class DALConfiguration
    {
        public static IServiceCollection ConfigureDALServices(IServiceCollection services, IConfiguration configuration)
        {
            string? connectionString = configuration.GetConnectionString(ConfigConstants.ConnectionStringName);

            if (!string.IsNullOrEmpty(connectionString))
            {
                services.AddSingleton(configuration);

                services.AddScoped(typeof(IBasicService<,>), typeof(BaseService<,>));

                services.AddScoped<IHomeService, HomeService>();
                services.AddScoped<ICategoryService, CategoryService>();
                services.AddScoped<IAboutService, AboutService>();
                services.AddScoped<IGalleryObjectService, GalleryObjectService>();
                services.AddScoped<IFilterService, FilterService>();

                services.AddScoped<IEmailSenderService, EmailSenderService>();

                services.AddScoped<IFilterRepository, FilterRepository>(provider => new FilterRepository(connectionString));
                services.AddScoped<IHomeRepository, HomeRepository>(provider => new HomeRepository(connectionString));
                services.AddScoped<IGalleryObjectRepository, GalleryObjectRepository>(provider => new GalleryObjectRepository(connectionString));

                services.AddScoped<Artists>(connectionString);
                services.AddScoped<Categories>(connectionString);
                services.AddScoped<Collections>(connectionString);
                services.AddScoped<CollectionParts>(connectionString);
                services.AddScoped<Directors>(connectionString);
                services.AddScoped<LouvreMuseumGalleries>(connectionString);
                services.AddScoped<GalleryObjects>(connectionString);
                services.AddScoped<Histories>(connectionString);
                services.AddScoped<Images>(connectionString);
                services.AddScoped<LouvreMuseumLevels>(connectionString);
                services.AddScoped<Literatures>(connectionString);
                services.AddScoped<Museams>(connectionString);
                services.AddScoped<OnDisplayNow>(connectionString);
                services.AddScoped<Raiting>(connectionString);
                services.AddScoped<Theme_Album>(connectionString);
                services.AddScoped<Users>(connectionString);
                services.AddScoped<Wings_floors>(connectionString);
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
            return services.AddScoped(typeof(IBasicRepository<TModel>), provider => new BaseRepository<TModel>(connnenctionString));
        }  

        public static MapperConfiguration ConfigureMapper()
        {
            MapperConfiguration mapperConfiguration = new(cfg =>
            {
                //Main configuration 
                cfg.CreateMap<Artists, ArtistAdapter>().ReverseMap();
                cfg.CreateMap<Categories, CategoryAdapter>().ReverseMap();
                cfg.CreateMap<Collections, CollectionAdapter>().ReverseMap();
                cfg.CreateMap<CollectionParts, CollectionPartAdapter>().ReverseMap();
                cfg.CreateMap<Directors, DirectorAdapter>().ReverseMap();
                cfg.CreateMap<LouvreMuseumGalleries, GalleryAdapter>().ReverseMap();
                cfg.CreateMap<GalleryObjects, GalleryObjectAdapter>().ReverseMap();
                cfg.CreateMap<Histories, HistoryAdapter>().ReverseMap();
                cfg.CreateMap<Images, ImageDboAdapter>().ReverseMap();
                cfg.CreateMap<LouvreMuseumLevels, LevelAdapter>().ReverseMap();
                cfg.CreateMap<Literatures, LiteratureAdapter>().ReverseMap();
                cfg.CreateMap<Museams, MuseumAdapter>().ReverseMap();
                cfg.CreateMap<OnDisplayNow, OnDisplayNowAdapter>().ReverseMap();
                cfg.CreateMap<Raiting, RatingAdapter>().ReverseMap();
                cfg.CreateMap<Theme_Album, ThemeAlbumAdapter>().ReverseMap();
                cfg.CreateMap<Users, UserAdapter>().ReverseMap();
                cfg.CreateMap<Wings_floors, WingsFloorsAdapter>().ReverseMap();
                cfg.CreateMap<FilterSectionModel, FilterSectionViewModel>().ReverseMap();
                
                //Secondary map
                cfg.CreateMap<SectionItem, SectionItemModel>().ReverseMap();
                //Another one ... like New...Adapter
            });

            mapperConfiguration.CreateMapper();
            return mapperConfiguration;
        }
    }



}