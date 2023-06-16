using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class AnalytiscSection
    {
        public int Activity { get; set; }
        public int ConnectionStability { get; set; }
        public int Files { get; set; }
        public int Comments { get; set; }

        public int TotalDatabaseRows { get; set; }

        public int CPU { get; set; }
        public string? DatabaseSize { get; set; }
        public int ActiveAdmins { get; set; }
        public int TotalBases { get; set;}

        public int TableCount { get; set; }
    }
}
