using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class Raitings
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Rating_ID { get; set; }
        public int Object_ID { get; set; }
        public int Rating { get; set; }
        public int ApplicationUser_ID { get; set; }
    }
}
