using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class HistoriesAdapter
    {
        public int History_ID { get; set; }
        public string? Previous_Owner { get; set; }
        public DateTime Acquisition_Date { get; set; }
        public string? Acquisition_Mode { get; set; }
        public string? Acquisition_Owner { get; set; }
        public string? Location { get; set; }
        public string? Depositary { get; set; }
        public string? Inscription_Signature { get; set; }
        public string? Historical_Notes { get; set; }
        public string? Additional_Info { get; set; }
    }

}
