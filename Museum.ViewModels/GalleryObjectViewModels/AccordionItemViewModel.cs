
namespace Museum.App.ViewModels.GalleryObject
{
    public class AccordionItemViewModel
    {
        public AccordionItemViewModel() { }

        public AccordionItemViewModel(string? headerText, string? collapseText)
        {
            HeaderText = headerText;
            CollapseText = collapseText;
        }

        public string? HeaderText { get; set; }
        public string? CollapseText { get; set; }
    }
}
