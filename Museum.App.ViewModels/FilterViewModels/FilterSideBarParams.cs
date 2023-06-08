using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.FilterViewModels
{
    public class FilterSideBarParams
    {
        public string tableName { get; set; } = string.Empty;
        public string labelName { get; set; } = string.Empty;
        public string tablePK { get; set; } = string.Empty;
        public string GalleryObjectFK { get; set; } = string.Empty;
    }
}
