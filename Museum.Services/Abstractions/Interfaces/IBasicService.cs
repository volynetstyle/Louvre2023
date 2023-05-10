using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicService<TModel, TAdapter>
        where TAdapter : class
        where TModel : class
    {
        void Add<TnewEnity>(TnewEnity item);
        void Add(TAdapter item);
        void Update(TAdapter item);
        abstract void Delete(TAdapter item);
        TAdapter GetById(int id);
        abstract IEnumerable<TAdapter> Find(Expression<Func<TAdapter, bool>> predicate);
        int Count();
        IEnumerable<TAdapter> Paginate(int pageNumber, int pageSize);
        IEnumerable<TAdapter> GetAll();
    }
}
