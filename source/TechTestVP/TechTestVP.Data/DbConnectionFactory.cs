using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TechTestVP.Data;

namespace TechTestVP.Data
{
    public class DbConnectionFactory : IDbConnectionFactory
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _connection => GetConnection();
        public DbConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
            OpenConnection();
        }

        private IDbConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DB"));
        }

        private void OpenConnection()
        {
            _connection.Open();
        }

        public async Task<IDataReader> ExecuteProcedure(string procName, Parameters parameters)
        {
            return await _connection.ExecuteReaderAsync(procName, parameters, commandType: CommandType.StoredProcedure);     
        }

        public async Task<int> ExecuteAsync(string sql)
        {
            return await _connection.ExecuteAsync(sql);
        }

        public async Task<int> ExecuteAsync(string sql, Parameters parameters )
        {
            return await _connection.ExecuteAsync(sql, parameters) ;
        }




    }
}
