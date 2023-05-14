using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class GalleryModel
    {
        public int GalleryId { get; set; }
        public string? GalleryNumber { get; set; }
        public int LevelId { get; set; }
        public int WfId { get; set; }
    }

}
