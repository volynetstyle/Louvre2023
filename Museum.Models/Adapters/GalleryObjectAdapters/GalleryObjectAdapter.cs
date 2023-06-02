namespace Museum.App.Services.Adapters
{
    public class GalleryObjectAdapter
    {
        public int ObjectID { get; set; }
        public int? CategoryID { get; set; }
        public int? ArtistID { get; set; }
        public int? GalleryID { get; set; }
        public int? CollectionID { get; set; }
        public int? MuseamID { get; set; }
        public int? PartID { get; set; }
        public int? HistoryID { get; set; }
        public int? ImageID { get; set; }
        public int? LiteratureID { get; set; }
        public string? Title { get; set; }
        public DateTime? CreationDate { get; set; }
        public string? Material { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public string? AcquisitionMode { get; set; }
        public string? AcquisitionOwner { get; set; }
        public DateTime? AcquisitionDate { get; set; }
        public string? Location { get; set; }
        public string? Depositary { get; set; }
        public string? InscriptionSignature { get; set; }
        public string? HistoricalNotes { get; set; }

    }
}
