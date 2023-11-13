using Clean.Domain.Core.Helpers;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Clean.Infrastructure.Repositories
{
    public class BaseConnection : IDisposable
    {
        public static IDbConnection DefaultConnection
        {
            get{
                return new SqlConnection(RuntimeConfigHelper.DefaultConnection);
            }
        }

        public void Dispose()
        {
            
        }
    }
}
