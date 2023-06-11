using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.Adapters
{
    public class CollectionPartsAdapter
    {
        [Key]
        public int Part_ID { get; set; }
        [ForeignKey("Collections")]
        public int Collection_ID { get; set; }
        public string? PartName { get; set; }
    }

}
