using Dommel;
using Microsoft.Data.SqlClient;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    public class BaseRepository<T> : IBasicRepository<T> where T : class
    {
        private readonly string _db;

        public BaseRepository(string db)
        {
            _db = db;
        }

        public void Add(T item)
        {
            using var sql = new SqlConnection(_db);
            sql.Insert(item);
        }

        public bool Any(Expression<Func<T, bool>> predicate)
        {
            using var sql = new SqlConnection(_db);
            return sql.Any(predicate);
        }

        public int Count()
        {
            using var sql = new SqlConnection(_db);
            return (int)sql.Count<T>();
        }

        public void Delete(int id)
        {
            using var sql = new SqlConnection(_db);
            sql.Delete(id);
        }

        public void Delete(T item)
        {
            using var sql = new SqlConnection(_db);
            sql.Delete(item);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            using var sql = new SqlConnection(_db);
            return sql.Select(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            using var sql = new SqlConnection(_db);
            return sql.GetAll<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            using var sql = new SqlConnection(_db);
            return await sql.GetAllAsync<T>();
        }

        public T GetById(int id)
        {
            using var sql = new SqlConnection(_db);
            var val = sql.Get<T>(id);
            if (val == null)
                throw new ArgumentNullException(nameof(val), "Item not found");
            return val;
        }

        public IEnumerable<T> Paginate(int pageNumber, int pageSize)
        {
            using var sql = new SqlConnection(_db);
            return sql.GetAll<T>().Skip((pageNumber - 1) * pageSize).Take(pageSize);
        }

        public void Update(T item)
        {
            using var sql = new SqlConnection(_db);
            sql.Update(item);
        }
    }
}
