using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.DataAccess
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;
        public SQLDataAccess(IConfiguration config) { _config = config; }

        public async Task<IEnumerable<T>> GetData<T, P>(string storedProcedure, P parameters, string ConnectionId = "SqlServerConnection_CommonDb")
        {
            string connectionString = _config.GetConnectionString(ConnectionId);
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException($"Connection string '{ConnectionId}' not found.");
            }
            using IDbConnection connection = new SqlConnection(connectionString: _config.GetConnectionString(ConnectionId));
            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string ConnectionId = "SqlServerConnection_CommonDb")
        {
            using IDbConnection connection = new SqlConnection(connectionString: _config.GetConnectionString(ConnectionId));
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
