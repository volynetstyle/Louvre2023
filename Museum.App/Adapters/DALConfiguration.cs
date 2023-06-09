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
using Museum.Models.Adapters;

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
                services.AddScoped<GalleryObjectsAdapter>(connectionString);
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
                cfg.CreateMap<ApplicationUser, ApplicationUserAdapter>().ReverseMap();
                cfg.CreateMap<ApplicationRole, ApplicationRoleAdapter>().ReverseMap();
                cfg.CreateMap<Comments, CommentsAdapter>().ReverseMap();
                cfg.CreateMap<CommentReplies, CommentRepliesAdapter>().ReverseMap();
                cfg.CreateMap<Artists, ArtistsAdapter>().ReverseMap();
                cfg.CreateMap<Categories, CategoriesAdapter>().ReverseMap();
                cfg.CreateMap<Collections, CollectionsAdapter>().ReverseMap();
                cfg.CreateMap<CollectionParts, CollectionPartsAdapter>().ReverseMap();
                cfg.CreateMap<Directors, DirectorsAdapter>().ReverseMap();
                cfg.CreateMap<LouvreMuseumGalleries, LouvreMuseumGalleriesAdapter>().ReverseMap();
                cfg.CreateMap<GalleryObjects, GalleryObjectsAdapter>().ReverseMap();
                cfg.CreateMap<Histories, HistoriesAdapter>().ReverseMap();
                cfg.CreateMap<Images, ImagesAdapter>().ReverseMap();
                cfg.CreateMap<LouvreMuseumLevels, LouvreMuseumLevelsAdapter>().ReverseMap();
                cfg.CreateMap<Literatures, LiteraturesAdapter>().ReverseMap();
                cfg.CreateMap<Museams, MuseamsAdapter>().ReverseMap();
                cfg.CreateMap<OnDisplayNow, OnDisplayNowAdapter>().ReverseMap();
                cfg.CreateMap<Raiting, RaitingAdapter>().ReverseMap();
                cfg.CreateMap<Theme_Album, Theme_AlbumAdapter>().ReverseMap();
                cfg.CreateMap<Users, UsersAdapter>().ReverseMap();
                cfg.CreateMap<Wings_floors, Wings_floorsAdapter>().ReverseMap();
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