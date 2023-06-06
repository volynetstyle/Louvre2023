namespace Museum.App.ViewModels.Home
{
    public class Section
    {
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public IEnumerable<SectionItem>? CategoryItem { get; set; }
    }
}
