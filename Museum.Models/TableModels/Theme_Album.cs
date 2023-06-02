using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class Theme_Album
    {
        public int Album_ID { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Object_ID { get; set; }
    }

}
