using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class RaitingAdapter
    {
        public int Rating_ID { get; set; }
        public int Object_ID { get; set; }
        public int Rating { get; set; }
        public int ApplicationUser_ID { get; set; }
    }
}
