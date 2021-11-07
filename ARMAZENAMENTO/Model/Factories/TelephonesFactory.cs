using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ARMAZENAMENTO.Model.Factories
{
    public class TelephonesFactory
    {

        private List<Tuple<string,string>> listaNomes { get; set; }
        
        private List<SqlParameter> listaCommandos {get; set; }
        public void PopulateNames()
        {
            Console.WriteLine("Quantos números de telefone deseja adicionar? ");
            int qntTelefones = Convert.ToInt32(Console.ReadLine());

            for(int i = 0; i < qntTelefones; i++) {
                Console.WriteLine("Insira o número completo: ");
                string numTelefone = Console.ReadLine();

                Console.WriteLine("Insira o tipo: ");
                string tipoTelefone = Console.ReadLine();

                var infTelefone = new Tuple<string,string>(numTelefone,tipoTelefone);
                listaNomes.Add(infTelefone);
            }
        }

        public void CreateParameters(string query)
        {
            int contador = 0;

            foreach(var telefone in listaNomes) {
                string novoTelefone = $"(@codAluno,@tipo{contador},@telefone{contador})";

                listaCommandos.Add(new SqlParameter($"@telefone{contador}",telefone.Item1));
                listaCommandos.Add(new SqlParameter($"@tipo{contador}",telefone.Item2));

                query += novoTelefone;
                if (contador < listaNomes.Count - 1) {
                    query += ",";
                } else {
                    query += ";";
                }
                contador++;
            }
        }

        public SqlCommand InjectParameters(CommandsFactory commandFactory)
        {
            foreach(var parametro in listaCommandos) {
                commandFactory.Command.Parameters.Add(parametro);
            }

            return commandFactory.Command;
        }
        
    }
}

