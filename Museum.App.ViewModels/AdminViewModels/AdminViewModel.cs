using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class AdminViewModel
    {
        public AnalytiscSection? AnalytiscSection { get; set; }
        public IEnumerable<LastPostViewModel?>? LastPostViewModel { get; set; }
        public IEnumerable<LatestUpdateViewModel?>? LatestUpdateViewModel { get; set; }
        public RatingStateViewModel? RatingStateViewModel { get; set; }
        public IEnumerable<UsersViewModel?>? UsersViewModel { get; set;}
    }
}
