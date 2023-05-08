using Dapper;
using Microsoft.Data.SqlClient;

namespace Museum.App.Services.Abstractions
{
    public abstract class BaseTableQuery<T>
    {
        protected readonly string connectionString;

        protected BaseTableQuery(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected abstract string TableName { get; }

        public abstract void Add(T item);

        public abstract void Update(T item);

        public abstract void Delete(T item);

        public abstract T GetById(int id);

        public abstract IEnumerable<T> GetAll();

        protected virtual SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        protected virtual string GetSelectQuery()
        {
            return $"SELECT * FROM {TableName}";
        }

        protected virtual string GetSelectByIdQuery()
        {
            return $"SELECT * FROM {TableName} WHERE Id = @id";
        }

        protected virtual string GetInsertQuery()
        {
            // TODO: реализовать генерацию запроса для добавления записи в таблицу
            return string.Empty;
        }

        protected virtual string GetUpdateQuery()
        {
            // TODO: реализовать генерацию запроса для обновления записи в таблице
            return string.Empty;
        }

        protected virtual string GetDeleteQuery()
        {
            // TODO: реализовать генерацию запроса для удаления записи из таблицы
            return string.Empty;
        }

        protected virtual DynamicParameters GetParameters(T item)
        {
            // TODO: реализовать генерацию параметров для запроса
            return new DynamicParameters();
        }

        protected virtual T QueryFirstOrDefault(string query, object? parameters = null)
        {
            using var connection = OpenConnection();
            return connection.QueryFirstOrDefault<T>(query, parameters);
        }

        protected virtual IEnumerable<T> Query(string query, object? parameters = null)
        {
            using var connection = OpenConnection();
            return connection.Query<T>(query, parameters);
        }

        public virtual void Execute(string query, object? parameters = null)
        {
            using var connection = OpenConnection();
            connection.Execute(query, parameters);
        }

        public virtual async Task ExecuteAsync(string query, object? parameters = null)
        {
            using var connection = OpenConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
