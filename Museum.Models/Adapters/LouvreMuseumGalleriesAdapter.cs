using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class LouvreMuseumGalleriesAdapter
    {
        public int Gallery_ID { get; set; }
        public string? GalleryNumber { get; set; }
        public int Level_ID { get; set; }
        public int WF_ID { get; set; }
    }

}
