using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.AdminViewModels
{
    public class UsersViewModel
    {
        public string? Name { get; set; }
        public string? Privilege { get; set; }
        public string? DatabaseName { get; set; }
        public DateTime? JoinDate { get; set; }
        public string? Priority { get; set;}
    }
}
