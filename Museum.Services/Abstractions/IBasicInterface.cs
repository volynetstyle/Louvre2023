using System.Collections;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicInterface<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(int id);
        void Delete(T item);
        T GetById(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Func<T, bool> predicate);
        int Count();
        bool Any();
        IEnumerable<T> Paginate(int pageNumber, int pageSize);
    }
}
