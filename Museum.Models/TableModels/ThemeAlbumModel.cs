using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class ThemeAlbumModel
    {
        public int AlbumId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int ObjectId { get; set; }
    }

}
