using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters
{
    public class RatingAdapter
    {
        public int RatingId { get; set; }
        public int ObjectId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
    }

}
