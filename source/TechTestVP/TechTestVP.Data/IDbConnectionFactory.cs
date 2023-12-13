using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestVP.Data
{
    public interface IDbConnectionFactory
    {
        Task<IDataReader> ExecuteProcedure(string procName, Parameters parameters);
        Task<int> ExecuteAsync(string sql);
        Task<int> ExecuteAsync(string sql, Parameters parameters);
    }
}
