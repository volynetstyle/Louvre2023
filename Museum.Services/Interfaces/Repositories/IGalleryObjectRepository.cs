using Museum.App.ViewModels.GalleryObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Interfaces.Repositories
{
    public interface IGalleryObjectRepository
    {
        public GalleryMainSectionImages GetGalleryObjectImages(int id);
    }
}
