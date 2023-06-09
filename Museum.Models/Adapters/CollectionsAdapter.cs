using System.ComponentModel.DataAnnotations;

namespace Museum.Models.Adapters
{
    public class CollectionsAdapter
    {
        [Key]
        public int Collection_ID { get; set; }
        public string? Department { get; set; }
        public DateTime PeriodStart { get; set; }
        public DateTime PeriodEnd { get; set; }
    }

}
