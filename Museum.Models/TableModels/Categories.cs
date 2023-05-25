using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class Categories
    {
        [Key]
        public int Category_ID { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public string? Keywords { get; set; }
        public string? Notes { get; set; }
    }

}
