using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class LiteratureModel
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
