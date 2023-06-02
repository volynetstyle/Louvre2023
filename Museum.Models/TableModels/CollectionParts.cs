using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class CollectionParts
    {
        public int Part_ID { get; set; }
        public int Collection_ID { get; set; }
        public string? PartName { get; set; }
    }

}
