using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters.CategoryAdapters
{
    public class CategoryAdapter
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Keywords { get; set; }
        public string? Notes { get; set; }
    }

}
