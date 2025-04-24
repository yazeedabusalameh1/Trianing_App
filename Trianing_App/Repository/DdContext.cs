using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Training_App.Data
{
    public class DBContext
    {
        private readonly string _connectionString;

        public DBContext(IConfiguration configuration)
        {
            //  connection string  |
            _connectionString = configuration.GetConnectionString("DbCon");
        }

        public SqlConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }

        
        public SqlConnection OpenConnection()
        {
            var connection = new SqlConnection(_connectionString);
            connection.Open();
            return connection;
        }
    }
}
