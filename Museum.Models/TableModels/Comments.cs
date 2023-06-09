using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.Models.TableModels
{
    public class Comments
    {
        public int Comment_ID { get; set; }
        public string? CommentText { get; set;}
        public int User_ID { get; set;}
    }
}
