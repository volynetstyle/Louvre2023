using AutoMapper;
using Museum.App.Services.Adapters;
using Museum.Models;

namespace Museum.App.Adapters.AutoMapperConfiguration
{
    public sealed class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
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
