using Museum.Models.Enums;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Collections;
using static Dapper.SqlMapper;

namespace Museum.App.Services.Abstractions
{ 
    public interface IBasicInterface<T>
    {
        void Add(T item);
        Task AddAsync(T item);
        
        void Update(T item);
        Task UpdateAsync(T item);

        void Delete(T item);
        Task DeleteAsync(T item);

        T GetById(int id);
        Task<T> GetByIdAsync(int id);

        IEnumerable<T> Find(Expression<Func<T, bool>> predicate);
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);

        int Count();
        int CountBy(Expression<Func<T, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountByAsync(Expression<Func<T, bool>> predicate);

        IEnumerable<T> Paginate(int pageNumber, int pageSize);
        Task<IEnumerable<T>> PaginateAsync(int pageNumber, int pageSize);

        IEnumerable<T> GetAll();
        public Task<IEnumerable<T>> GetAllAsync();
        
        public bool Any(Expression<Func<T, bool>> predicate);
        public Task<bool> AnyAsync(Expression<Func<T, bool>> predicate);
    }
}
