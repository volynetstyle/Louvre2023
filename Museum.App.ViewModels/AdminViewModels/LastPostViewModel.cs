using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class LastPostViewModel
    {
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public int AverageRating { get; set; }
        public string? Description { get; set; }
    }
}
