using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.FilterModels
{
    public class FilterSectionModel
    {
        public int OBJECT_ID { get; set; }
        public string? ImageUrl { get; set; }
        public string? Tags { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
    }
}
