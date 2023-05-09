using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters
{
    public class LiteratureAdapter
    {
        public int LiteratureID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public string? ISBN { get; set; }
        public string? AdditionalInfo { get; set; }
    }
}
