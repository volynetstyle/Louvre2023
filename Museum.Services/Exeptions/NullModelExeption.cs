using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Exeptions
{
    public class ModelNullExeption : Exception
    {
        public ModelNullExeption(string message) : base(message)
        {
        }

        public ModelNullExeption(string message, Exception innerException) 
            : base(message, innerException)
        {
        }
    }

}
