
namespace Museum.App.ViewModels.GalleryObject
{
    public class AccordionViewModel
    {
        public AccordionViewModel() { }

        public AccordionViewModel(IEnumerable<AccordionItemViewModel>? accordions)
        {
            this.accordions = accordions;
        }

        public IEnumerable<AccordionItemViewModel>? accordions;
    }
}
