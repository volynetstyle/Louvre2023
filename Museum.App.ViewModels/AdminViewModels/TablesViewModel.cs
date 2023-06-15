using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class TablesViewModel
    {
        public IEnumerable<string>? TableNames { get; set; }
        public dynamic? Tables { get; set; }
    }
}
