using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models
{
    public class RatingModel
    {
        public int RatingId { get; set; }
        public int ObjectId { get; set; }
        public int UserId { get; set; }
        public int Rating { get; set; }
    }

}
