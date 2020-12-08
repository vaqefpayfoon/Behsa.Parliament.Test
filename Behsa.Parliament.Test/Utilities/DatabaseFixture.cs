using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace Behsa.Parliament.Test.Utilities
{
    public class DatabaseFixture : IDisposable
    {
        SqlConnection connection;

        public async Task<SqlDataReader> GetDataReader(string query)
        {
            string cnnString = ConfigurationManager.AppSettings["ReplicatedConnection"];

            connection = new SqlConnection()
            {
                ConnectionString = cnnString
            };
            SqlCommand cmd = new SqlCommand()
            {
                Connection = connection,
                CommandText = query,
                CommandType = CommandType.Text
            };
            if (connection.State == ConnectionState.Closed)
                await connection.OpenAsync();

            SqlDataReader dr = await cmd.ExecuteReaderAsync();
            return dr;
        }

        public void Dispose()
        {
            connection.Close();
        }
    }

}
