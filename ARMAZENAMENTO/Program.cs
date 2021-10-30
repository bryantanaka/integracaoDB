using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ARMAZENAMENTO
{
    class Program
    {   
        static void Main(string[] args)
        {   
            string strConexao = "Server=localhost; Database=Sabado; Trusted_Connection=True";

            SqlConnection conexao = null;
            try {
                conexao = new SqlConnection( strConexao );
                conexao.Open();
                
                string queryStringAluno = "select * from Aluno where nomeCompleto=@nome";
                SqlCommand comando = new SqlCommand(queryStringAluno, conexao);
                comando.Parameters.Add(new SqlParameter("@nome","asdiasd"));

                Object idAluno = comando.ExecuteScalar();

                if(idAluno == null) {
                    Console.WriteLine("Insira o primeiro nome do aluno: ");
                    string nome = Console.ReadLine();
                    Console.WriteLine("Insira a data de nascimento: ");
                    string dataNascimento = Console.ReadLine();
                    Console.WriteLine("Insira o sobrenome do aluno: ");
                    string sobrenome = Console.ReadLine();

                    string queryStringNovoAluno = "insert into Aluno(nome,dataNascimento,sobrenome) values (@nome, @dataNascimento, @sobrenome)";
                    SqlCommand comandoNovoAluno = new SqlCommand(queryStringNovoAluno, conexao);
                    comandoNovoAluno.Parameters.Add(new SqlParameter("@nome",nome));
                    comandoNovoAluno.Parameters.Add(new SqlParameter("@dataNascimento",dataNascimento));
                    comandoNovoAluno.Parameters.Add(new SqlParameter("@sobrenome",sobrenome));

                    int alunosCriados = (int)comandoNovoAluno.ExecuteNonQuery();

                    Console.WriteLine("Alunos criados: " + alunosCriados.ToString());

                    string queryStingGetCod = "select codAluno from Aluno where nome=@nome";
                    SqlCommand comandoGetCodAluno = new SqlCommand(queryStingGetCod, conexao);
                    comandoGetCodAluno.Parameters.Add(new SqlParameter("@nome",nome));
                    int idNovoAluno = (int)comandoGetCodAluno.ExecuteScalar();

                    Console.WriteLine("Quantos números de telefone deseja adicionar? ");
                    int qntTelefones = Convert.ToInt32(Console.ReadLine());

                    var listaNomes = new List<Tuple<string,string>>();

                    for(int i = 0; i < qntTelefones; i++) {
                        Console.WriteLine("Insira o número completo: ");
                        string numTelefone = Console.ReadLine();

                        Console.WriteLine("Insira o tipo: ");
                        string tipoTelefone = Console.ReadLine();

                        var infTelefone = new Tuple<string,string>(numTelefone,tipoTelefone);
                        listaNomes.Add(infTelefone);
                    }

                    string queryStringNovoTelefone = "insert into Telefone(codAluno,tipo,telefone) values";
                    int contador = 0;

                    var listaTelefones = new List<SqlParameter>();
                    foreach(var telefone in listaNomes) {
                        string novoTelefone = $"(@codAluno,@tipo{contador},@telefone{contador})";

                        listaTelefones.Add(new SqlParameter($"@telefone{contador}",telefone.Item1));
                        listaTelefones.Add(new SqlParameter($"@tipo{contador}",telefone.Item2));

                        queryStringNovoTelefone += novoTelefone;
                        if (contador < listaNomes.Count - 1) {
                            queryStringNovoTelefone += ",";
                        } else {
                            queryStringNovoTelefone += ";";
                        }
                        contador++;
                    }

                    SqlCommand comandoNovoTelefone = new SqlCommand(queryStringNovoTelefone, conexao);

                    comandoNovoTelefone.Parameters.Add(new SqlParameter("@codAluno",idNovoAluno));

                    foreach(var parametro in listaTelefones) {
                        comandoNovoTelefone.Parameters.Add(parametro);
                    }

                    comandoNovoTelefone.ExecuteNonQuery();
                    System.Console.WriteLine("Aluno criado!");
                } else {
                    string queryStringTelefone = "select * from Telefone where codAluno=@cod";
                    SqlCommand comandoTelfone = new SqlCommand(queryStringTelefone, conexao);
                    comandoTelfone.Parameters.Add(new SqlParameter("@cod",idAluno));

                    SqlDataReader leitor = comandoTelfone.ExecuteReader();

                    while(leitor.Read()) {
                        System.Console.WriteLine(leitor[3]);
                    }
                }
                           
                conexao.Close();
            } catch (Exception e){
                Console.WriteLine("Problemas para estabelecer a conexão!");
                Console.WriteLine(e);
            } finally {
                if ( conexao != null )
                    conexao.Close();
            }
        }
    }
}

