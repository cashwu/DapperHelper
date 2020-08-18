using System;
using System.Data.SQLite;
using System.Threading.Tasks;

namespace testDapper
{
    public class BaseDAL
    {
        protected string ConnectionString { get; set; }

        public async Task<T> Execute<T>(Func<SQLiteConnection, SQLiteTransaction, T> func)
        {
            return await Execute(ConnectionString, func);
        }

        public async Task<T> Execute<T>(string connectionString, Func<SQLiteConnection, SQLiteTransaction, T> func)
        {
            await using var connection = new SQLiteConnection(connectionString ?? ConnectionString);

            await connection.OpenAsync();

            await using var transaction = connection.BeginTransaction();

            return func(connection, transaction);
        }
    }
}