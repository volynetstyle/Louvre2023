using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{   
    public class LiteraturesAdapter
    {
        public int Literature_ID { get; set; }
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? Publisher { get; set; }
        public DateTime Publication_Date { get; set; }
        public string? ISBN { get; set; }
        public string? Additional_Info { get; set; }
        public int Object_ID { get; set; }
    }
}
