using Museum.Models.Enums;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{ 
    public interface IBasicInterface<T>
    {
        void Add(T item);
        void Update(T item);
        void Delete(T item);
        T GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        int Count();
        IEnumerable<T> Paginate(int pageNumber, int pageSize);
        IEnumerable<T> GetAll();
        bool Any(Expression<Func<T, bool>> predicate);

        Task AddAsync(T item);
        Task UpdateAsync(T item);
        Task DeleteAsync(T item);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<int >CountAsync();
        Task<IEnumerable<T> >PaginateAsync(int pageNumber, int pageSize);
        Task<IEnumerable<T>> GetAllAsync();
        Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
