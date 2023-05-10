using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicService<TModel, TAdapter> : IBasicInterface<TAdapter>
        where TAdapter : class
        where TModel : class
    {
        void Add<TnewEnity>(TnewEnity item);
    }
}
