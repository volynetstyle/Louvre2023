﻿namespace Museum.App.Services.Adapters
{
    public class GalleryObjectAdapter
    {
        public int Object_ID { get; set; }
        public int? Category_ID { get; set; }
        public int? Artist_ID { get; set; }
        public int? Gallery_ID { get; set; }
        public int? Collection_ID { get; set; }
        public int? Museam_ID { get; set; }
        public int? Part_ID { get; set; }
        public int? History_ID { get; set; }
        public int? LiteratureID { get; set; }

        public string? title { get; set; }
        public DateTime? creation_date { get; set; }
        public string? material { get; set; }
        public int? width { get; set; }
        public int? height { get; set; }
        public string? acquisition_mode { get; set; }
        public string? acquisition_owner { get; set; }
        public DateTime? acquisition_date { get; set; }
        public string? location { get; set; }
        public string? depositary { get; set; }
        public string? inscription_signature { get; set; }
        public string? historical_notes { get; set; }

    }
}