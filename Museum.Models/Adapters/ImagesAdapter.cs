using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class ImagesAdapter
    {
        public int Image_ID { get; set; }
        public string? Image_Loc { get; set; }
        public string? Photographer { get; set; }
        public DateTime Date_Taken { get; set; }
        public string? Additional_Info { get; set; }
        public int Object_ID { get; set; }
    }
}
