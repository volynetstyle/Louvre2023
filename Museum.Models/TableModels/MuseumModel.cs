using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class MuseumModel
    {
        public int MuseumId { get; set; }
        public string? MuseumName { get; set; }
        public string? Location { get; set; }
        public int DirrId { get; set; }
    }

}
