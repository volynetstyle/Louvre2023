using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicRepository<T> : IBasicInterface<T>
    {
        public bool Any(Expression<Func<T, bool>> predicate);
    }
}
