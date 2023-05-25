using Museum.Models.Enums;
using System.Linq.Expressions;

namespace Museum.App.Services.Abstractions
{
    public interface IBasicRepository<T> : IBasicInterface<T>
    {
        public bool Any(Expression<Func<T, bool>> predicate);

        public Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<dynamic> Join<T1, T2>(JoinType join, string splitOn = "Id")
          where T1 : class where T2 : class;

        Task<IEnumerable<dynamic>> JoinAsync<T1, T2>(JoinType join, T1 firstModel, T2 secondModel, string splitOn = "Id")
            where T1 : class where T2 : class;

        IEnumerable<dynamic> Join<T1, T2, T3>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, string splitOn = "Id")
            where T1 : class where T2 : class where T3 : class;

        Task<IEnumerable<dynamic>> JoinAsync<T1, T2, T3>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, string splitOn = "Id")
            where T1 : class where T2 : class where T3 : class;

        IEnumerable<dynamic> Join<T1, T2, T3, T4>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, T4 fourModel, string splitOn = "Id")
            where T1 : class where T2 : class where T3 : class where T4 : class;

        Task<IEnumerable<dynamic>> JoinAsync<T1, T2, T3, T4>(JoinType join, T1 firstModel, T2 secondModel, T3 thirdModel, T4 fourModel, string splitOn = "Id")
           where T1 : class where T2 : class where T3 : class where T4 : class;
    }
}