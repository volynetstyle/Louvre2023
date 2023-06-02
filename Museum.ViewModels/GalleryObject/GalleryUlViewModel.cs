
namespace Museum.App.ViewModels.GalleryObject
{
    public class GalleryUlViewModel
    {
        public GalleryUlViewModel(string title, DateTime createDate, string location, string depositary, string description)
        {
            Title = title;
            Create_Date = createDate;
            Location = location;
            Depositary = depositary;
            Description = description;
        }

        public string Title { get; set; }
        public DateTime Create_Date { get; set; }
        public string Location { get; set; }
        public string Depositary { get; set; }
        public string Description { get; set; }
    }
}
