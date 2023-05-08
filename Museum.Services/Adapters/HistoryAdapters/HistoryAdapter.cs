using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters.HistoryAdapters
{
    public class HistoryAdapter
    {
        public int HistoryID { get; set; }
        public string? PreviousOwner { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string? AcquisitionMode { get; set; }
        public string? AcquisitionOwner { get; set; }
        public string? Location { get; set; }
        public string? Depositary { get; set; }
        public string? InscriptionSignature { get; set; }
        public string? HistoricalNotes { get; set; }
        public string? AdditionalInfo { get; set; }
    }

}
