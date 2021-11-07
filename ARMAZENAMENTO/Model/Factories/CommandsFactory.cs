using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ARMAZENAMENTO.Model.Factories
{
    public class CommandsFactory
    {
        public SqlCommand Command { get; private set; }
        private string Query { get; set; }
        private SqlConnection Connection { get; init; }

        public CommandsFactory(SqlConnection connection)
        {
            Connection = connection;
        }

        public SqlCommand Create(string queryString)
        {
            Command = new SqlCommand(queryString, Connection);
            return Command;

        }

        public SqlCommand AddParam(string key, string value)
        {
            Command.Parameters.Add(new SqlParameter(key, value));
            return Command;
        }

        public void AddParams(Tuple<string, string>[] parameters)
        {
            foreach(var parameter in parameters)
            {
                AddParam(parameter.Item1, parameter.Item2);
            }
        }

    }
}

