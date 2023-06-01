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
        public int Image_ID { get; set; }
        public string? Image_Loc { get; set; }
        public string? Photographer { get; set; }
        public DateTime Date_Taken { get; set; }
        public string? Additional_Info { get; set; }
    }
}
