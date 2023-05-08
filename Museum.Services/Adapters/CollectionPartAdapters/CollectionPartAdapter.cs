using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Adapters.CollectionPartAdapters
{
    public class CollectionPartAdapter
    {
        public int PartId { get; set; }
        public int CollectionId { get; set; }
        public string? PartName { get; set; }
    }

}
