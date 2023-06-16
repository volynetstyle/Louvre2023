using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Abstractions;
using Museum.App.Services.Interfaces.Repositories;
using Museum.App.ViewModels.AdminViewModels;
using Museum.Models.Adapters;
using Museum.Models.TableModels;

namespace Museum.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IAdminRepository _adminRepository;
        private readonly IBasicService<Literatures, LiteraturesAdapter> _lit;
        private readonly IBasicService<Images, ImagesAdapter> _img;
        private readonly IBasicService<Categories, CategoriesAdapter> _categoriesService;
        private readonly IBasicService<Artists, ArtistsAdapter> _artistsService;
        private readonly IBasicService<LouvreMuseumGalleries, LouvreMuseumGalleriesAdapter> _louvreMuseumGalleriesService;
        private readonly IBasicService<Collections, CollectionsAdapter> _collectionsService;
        private readonly IBasicService<Museams, MuseamsAdapter> _museumsService;
        private readonly IBasicService<CollectionParts, CollectionPartsAdapter> _partsService;
        private readonly IBasicService<GalleryObjects, GalleryObjectsAdapter> _galleryObjectsService;

        public AdminController( ILogger<AdminController> logger, 
                                IAdminRepository adminRepository,
                                IBasicService<Literatures, LiteraturesAdapter> lit, IBasicService<Images, ImagesAdapter> img,
                                IBasicService<Categories, CategoriesAdapter> categoriesService,
                                IBasicService<Artists, ArtistsAdapter> artistsService,
                                IBasicService<LouvreMuseumGalleries, LouvreMuseumGalleriesAdapter> louvreMuseumGalleriesService,
                                IBasicService<Collections, CollectionsAdapter> collectionsService,
                                IBasicService<Museams, MuseamsAdapter> museumsService,
                                IBasicService<CollectionParts, CollectionPartsAdapter> partsService,
                                IBasicService<GalleryObjects, GalleryObjectsAdapter> galleryObjectsService)
        {
            _logger = logger;
            _adminRepository = adminRepository;
            _lit = lit;
            _img = img;
            _categoriesService = categoriesService;
            _artistsService = artistsService;
            _louvreMuseumGalleriesService = louvreMuseumGalleriesService;
            _collectionsService = collectionsService;
            _museumsService = museumsService;
            _partsService = partsService;
            _galleryObjectsService = galleryObjectsService;
        }

        public IActionResult Index()
        {
            return View("Index", new AdminViewModel
            {
                AnalytiscSection = _adminRepository.GetAnalytiscSection(),
                LastPostViewModel = _adminRepository.GetLastPostViewModel(),
                LatestUpdateViewModel= _adminRepository.GetLatestUpdateViewModel(),
                RatingStateViewModel = _adminRepository.GetRatingStateViewModel(),
            }) ;
        }

        public IActionResult Backup()
        {
            return View("Backup");
        }

        [HttpPost]
        public ActionResult CreateBackup(string backupType)
        {
            switch (backupType)
            {
                case "full":
                    _adminRepository.CreateFullBackup();
                    break;
                case "incremental":
                    _adminRepository.CreateIncrementalBackup();
                    break;
                case "differential":
                    _adminRepository.CreateDifferentialBackup();
                    break;
                default:
                    return View("Backup"); ; 
            }
            return View("Backup"); ; 
        }

        [HttpPost]
        public IActionResult SelectTable(string tableSelect)
        {
            return View("Tables", new TablesViewModel
            {
                TableNames = _adminRepository.GetTableNames(),
                Tables = _adminRepository.GetTables(tableSelect)
            });
        }

        public IActionResult Tables()
        {
            return View("Tables", new TablesViewModel
            {
                TableNames = _adminRepository.GetTableNames(),
                Tables = _adminRepository.GetTables("GalleryObjects")
            });
        }

        [HttpPost]
        public ActionResult Update(string tableName, int id)
        {
            
            return View("Tables", new TablesViewModel
            {
                TableNames = _adminRepository.GetTableNames(),
                Tables = _adminRepository.GetTables(tableName)
            });
        }

        [HttpPost]
        public ActionResult Delete(string tableName, int id)
        {
            _adminRepository.Delete(tableName, id);
            return View("Tables", new TablesViewModel
            {
                TableNames = _adminRepository.GetTableNames(),
                Tables = _adminRepository.GetTables(tableName)
            });
        }

        public IActionResult AddLiterature(LiteraturesAdapter literature)
        {
            _lit.Add(literature);
            return EditContent();
        }

        public IActionResult AddImages(ImagesAdapter images)
        {
            _img.Add(images);
            return EditContent();
        }

        public IActionResult AddObject(GalleryObjectsAdapter galleryObjectsAdapter)
        {
            _galleryObjectsService.Add(galleryObjectsAdapter);
            return EditContent();
        }

        public IActionResult EditContent()
        {
            var categories = _categoriesService.GetAll();
            var artists = _artistsService.GetAll();
            var louvreMuseumGalleries = _louvreMuseumGalleriesService.GetAll();
            var collections = _collectionsService.GetAll();
            var museums = _museumsService.GetAll();
            var parts = _partsService.GetAll();
            var galleryObjects = _galleryObjectsService.GetAll();

            return View("EditContent", new EditViewModel
            {
                categoriesAdapters = categories,
                artistsAdapters = artists,
                louvreMuseumGalleriesAdapters = louvreMuseumGalleries,
                collectionsAdapters = collections,
                museamsAdapters = museums,
                PartsAdapters = parts,
                galleryObjectsAdapters = galleryObjects
            });
        }
    }
}
