using Museum.App.ViewModels.AdminViewModels;
using Dapper;
using Microsoft.Data.SqlClient;
using Museum.App.Services.Interfaces.Repositories;
using System.Data;

namespace Museum.App.Services.Implementation.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _conn;
        private const string _path = "C:\\Users\\1\\source\\repos\\Louvre2023\\Museum.Server.MSSSQ\\Backup\\";

        public AdminRepository(string conn) 
        {
            _conn = conn;
        }
        
        public dynamic GetTables(string tableName)
        {
            using var connection = new SqlConnection(_conn);
            return connection.Query<dynamic>($"SELECT * FROM {tableName}");
        }
        public IEnumerable<string> GetTableNames()
        {
            using var connection = new SqlConnection(_conn);
            return connection.Query<string>("SELECT name FROM sys.tables");            
        }

        public AnalytiscSection? GetAnalytiscSection()
        {
            using var sql = new SqlConnection(_conn);
            return sql.QueryFirstOrDefault<AnalytiscSection>("select * from ST_AnalytiscSection");
        }

        public IEnumerable<LastPostViewModel?> GetLastPostViewModel()
        {
            using var sql = new SqlConnection(_conn);
            return sql.Query<LastPostViewModel>("select * from ST_LastPostViewModel");
        }

        public IEnumerable<LatestUpdateViewModel?> GetLatestUpdateViewModel()
        {
            using var sql = new SqlConnection(_conn);
            return sql.Query<LatestUpdateViewModel>("select * from ST_LatestUpdateViewModel");
        }

        public RatingStateViewModel? GetRatingStateViewModel()
        {
            using var sql = new SqlConnection(_conn);
            return sql.QueryFirstOrDefault<RatingStateViewModel>("select * from ST_RatingState");
        }

        public IEnumerable<UsersViewModel?>? GetUsersViewModel()
        {
            throw new NotImplementedException();
        }

        public void Delete(string tableName, int id)
        {
            using var sql = new SqlConnection(_conn);
            string idColumnName = sql.ExecuteScalar<string>(
                $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = @TableName AND COLUMN_NAME LIKE '%Id%'", 
                new { TableName = tableName });

            if (idColumnName != null)
            {
                sql.Execute($"DELETE FROM {tableName} WHERE {idColumnName} = @Id", new { Id = id });
            }
            else
            {
                throw new Exception("ID column not found in the specified table.");
            }
        }

        public void CreateFullBackup()
        {
            
            using (var sql = new SqlConnection(_conn))
            {
                sql.Open();

                var dbName = sql.Database;

                var backupFilePath = $"{_path}{dbName}_Full_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var query = $"BACKUP DATABASE [{dbName}] TO DISK = '{backupFilePath}' WITH FORMAT";

                using (var command = new SqlCommand(query, sql))
                {
                    command.ExecuteNonQuery();
                }

                sql.Close();
            }
        }

        public void CreateIncrementalBackup()
        {
            using (var sql = new SqlConnection(_conn))
            {
                sql.Open();

                var dbName = sql.Database;

                var backupFilePath = $"{_path}{dbName}_Incremental_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var query = $"BACKUP DATABASE [{dbName}] TO DISK = '{backupFilePath}' WITH DIFFERENTIAL";

                using (var command = new SqlCommand(query, sql))
                {
                    command.ExecuteNonQuery();
                }

                sql.Close();
            }
        }

        public void CreateDifferentialBackup()
        {
            using (var sql = new SqlConnection(_conn))
            {
                sql.Open();

                var dbName = sql.Database;

                var backupFilePath = $"{_path}{dbName}_Differential_{DateTime.Now:yyyyMMddHHmmss}.bak";
                var query = $"BACKUP DATABASE [{dbName}] TO DISK = '{backupFilePath}' WITH DIFFERENTIAL";

                using (var command = new SqlCommand(query, sql))
                {
                    command.ExecuteNonQuery();
                }

                sql.Close();
            }
        }



        //public IEnumerable<UsersViewModel?> GetUsersViewModel()
        //{
        //    using var sql = new SqlConnection(_conn);
        //    return new();
        //}
    }
}
