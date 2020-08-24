using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Izmainas.Data
{
    public class MySqlDataAccess : IMySqlDataAccess
    {
        private readonly IConfiguration _configuration;

        public MySqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString(string name)
        {
            return _configuration.GetConnectionString(name);
        }

        public async Task<List<T>> LoadData<T, U>(string statement, U parameters, string connectionStringName)
        {
            using (IDbConnection connection = new MySqlConnection(GetConnectionString(connectionStringName)))
            {
                var rows = await connection.QueryAsync<T>(statement, parameters, commandType: CommandType.StoredProcedure);
                return rows.ToList();
            }
        }

        public Task SaveData<T>(string statement, T parameters, string connectionStringName)
        {
            using (IDbConnection connection = new MySqlConnection(GetConnectionString(connectionStringName)))
            {
                return connection.ExecuteAsync(statement, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
