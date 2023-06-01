using Dapper;
using Dommel;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Attributes;
using Museum.Models.Enums;
using System.Data;
using System.Linq.Expressions;
using static Dapper.SqlMapper;
using static Dommel.DommelMapper;

namespace Museum.App.Services.Abstractions
{
    [Repository]
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

        private static string GetTableName<TModel>(IDbConnection connection) where TModel : class 
        {
            return Resolvers.Table(typeof(TModel), GetSqlBuilder(connection));
        }

        private static string GetJoinSql(JoinType join)
        {
            return join switch
            {
                JoinType.Inner => "INNER JOIN",
                JoinType.Left => "LEFT JOIN",
                JoinType.Right => "RIGHT JOIN",
                JoinType.Cross => "CROSS JOIN",
                _ => "JOIN"
            };
        }

        public IEnumerable<dynamic> Join<T1, T2>(JoinType join, string splitOn = "Id")
            where T1 : class
            where T2 : class
        {
            throw new NotImplementedException();

        }

        public async Task<IEnumerable<dynamic>> JoinAsync<T1, T2>(JoinType join, T1 firstModel, T2 secondModel, string splitOn = "Id")
            where T1 : class
            where T2 : class
        {
            using var sql = new SqlConnection(_db);
            string joinSql = BaseRepository<T>.GetJoinSql(join);
            string query = $@"SELECT *FROM {GetTableName<T1>(sql)} AS T1{joinSql}{GetTableName<T2>(sql)} AS T2 ON T1.Id = T2.T1Id";

            return await sql.QueryAsync<dynamic, dynamic, dynamic>(
                query,
                (a, b) => new { T1 = a, T2 = b },
                new { firstModel, secondModel },
                splitOn: splitOn);
        }

        public IEnumerable<dynamic> Join<T1, T2, T3>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, string splitOn = "Id")
            where T1 : class
            where T2 : class
            where T3 : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<dynamic>> JoinAsync<T1, T2, T3>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, string splitOn = "Id")
            where T1 : class
            where T2 : class
            where T3 : class
        {
            throw new NotImplementedException();
        }

        public IEnumerable<dynamic> Join<T1, T2, T3, T4>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, T4 fourModel, string splitOn = "Id")
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<dynamic>> JoinAsync<T1, T2, T3, T4>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, T4 fourModel, string splitOn = "Id")
            where T1 : class
            where T2 : class
            where T3 : class
            where T4 : class
        {
            throw new NotImplementedException();
        }
    }
}
