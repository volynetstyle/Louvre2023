using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicRepository<T>
    {
        public bool Any(Expression<Func<T, bool>> predicate);
        void Add(T item);
        void Update(T item);
        abstract void Delete(T item);
        T GetById(int id);
        abstract IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        int Count();
        IEnumerable<T> Paginate(int pageNumber, int pageSize);
        IEnumerable<T> GetAll();
    }
}
