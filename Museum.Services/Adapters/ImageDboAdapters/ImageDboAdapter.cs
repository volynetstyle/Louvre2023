using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters
{
    public class ImageDboAdapter
    {
        public int ImageID { get; set; }
        public string? ImageLoc { get; set; }
        public string? Photographer { get; set; }
        public DateTime DateTaken { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
