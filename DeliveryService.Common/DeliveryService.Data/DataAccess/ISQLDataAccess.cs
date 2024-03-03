using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Data.DataAccess
{
    public interface ISQLDataAccess
    {
        Task<IEnumerable<T>> GetData<T, P>(string storedProcedure, P parameters, string ConnectionId = "SqlServerConnection_CommonDb");
        Task SaveData<T>(string storedProcedure, T parameters, string ConnectionId = "SqlServerConnection_CommonDb");
    }
}
