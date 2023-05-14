using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.FilterModels
{
    public class CheckboxModel
    {
        public int Id { get; set; }
        public string? Label { get; set; }
        public int Count { get; set; }
        public bool IsChecked { get; set; }
    }
}
