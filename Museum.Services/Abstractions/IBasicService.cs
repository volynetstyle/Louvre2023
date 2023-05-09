using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Abstractions
{
    internal interface IBasicService<T> : IBasicInterface<T>
    { 
        string ConnectionString { get; set; }
    }
}
