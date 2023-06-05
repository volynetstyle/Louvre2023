namespace Museum.Models.TemplateModels
{
    public class DefinitionModel
    {
        public string? Title {get; set;}
        public IEnumerable<DefinitionItem>? DefinitionItem {get; set;}
    }
}