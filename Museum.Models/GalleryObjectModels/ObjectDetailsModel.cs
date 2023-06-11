using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.GalleryObjectModels
{
    public class ObjectDetailsModel
    {
        public int Object_ID { get; set; }
        public string? ObjectTitle { get; set; }
        public DateTime CreationDate { get; set; }
        public string? Material { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public string? AcquisitionMode { get; set; }
        public string? AcquisitionOwner { get; set; }
        public DateTime AcquisitionDate { get; set; }
        public string? Location { get; set; }
        public string? Depositary { get; set; }
        public string? InscriptionSignature { get; set; }
        public string? HistoricalNotes { get; set; }
        public string? GalleryNumber { get; set; }
        public string? LevelNumber { get; set; }
        public string? FloorName { get; set; }
    }

}
