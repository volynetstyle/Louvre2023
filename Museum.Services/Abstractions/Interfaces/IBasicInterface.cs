using System.Collections;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicInterface<T>
    {
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
