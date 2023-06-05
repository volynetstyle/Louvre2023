using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Exeptions
{
    public class EmptyValue : Exception
    {
        public EmptyValue() 
            : base("The value is empty!") 
        { 
        }

        public EmptyValue(string message) 
            : base(message)
        {
        }

        public EmptyValue(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
