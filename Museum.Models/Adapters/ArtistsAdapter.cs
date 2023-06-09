using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class ArtistsAdapter
    {
        [Key]
        public int ArtistId { get; set; }
        public string? FullName { get; set; }
        public DateTime Birth_Date { get; set; }
        public DateTime Death_Date { get; set; }
        public string? Style { get; set; }
        public string? Genres { get; set; }
    }

}
