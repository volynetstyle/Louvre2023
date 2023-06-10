using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.ViewModels.FilterViewModels
{
    public class VoteViewModel
    {
        public VoteViewModel() { }

        public VoteViewModel(int object_ID, int raiting, int applicationUser_ID)
        {
            Object_ID = object_ID;
            Raiting = raiting;
            ApplicationUser_ID = applicationUser_ID;
        }

        public int Object_ID { get; set; }
        public int Raiting { get; set; }
        public int ApplicationUser_ID { get; set; }
    }
}
