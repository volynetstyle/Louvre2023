using Museum.App.ViewModels.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.Filter
{
    public class DepartmentSection
    {
        public string? DepartmentName { get; set; }
        public string? DepartmentDescription { get; set; }
        public IEnumerable<SectionItem>? DepartmentItem { get; set; }
    }
}
