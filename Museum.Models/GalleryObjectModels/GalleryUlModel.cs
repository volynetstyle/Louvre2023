using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.GalleryObjectModels
{
    public class GalleryUlModel
    {
        public string? Title { get; set; }
        public DateTime Create_Date { get; set; }
        public string? Location { get; set; }
        public string? Depositary { get; set; }
        public string? Description { get; set; }
    }
}
