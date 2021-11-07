using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ARMAZENAMENTO.Model.Factories
{
    public class DbConnectionFactory 
    {
        private string _connectionString { get; init; }
        public DbConnectionFactory()
        {
            _connectionString = "Server=localhost; Database=Sabado; Trusted_Connection=True";
        }
        public SqlConnection Create()
        {
            var dbConnection = new SqlConnection(_connectionString);
            return dbConnection;
        }
    }
}
