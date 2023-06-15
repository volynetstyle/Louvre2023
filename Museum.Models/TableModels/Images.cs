using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class Images
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Image_ID { get; set; }
        public string? Image_Loc { get; set; }
        public string? Photographer { get; set; }
        public DateTime Date_Taken { get; set; }
        public string? Additional_Info { get; set; }
        public int Object_ID { get; set; }
    }
}
