using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using ARMAZENAMENTO.Model.Factories;

namespace ARMAZENAMENTO
{
    class Program
    {   
        static void Main(string[] args)
        {   
            var dbConnectionFactory = new DbConnectionFactory();
            var connection = dbConnectionFactory.Create();
            var commandsFactory = new CommandsFactory(connection);

            try {
                connection.Open();
                
                commandsFactory.Create("select * from Aluno where nomeCompleto=@nome");
                
                var command = commandsFactory.AddParam("@nome","asdiasd");
             
                Object idAluno = command.ExecuteScalar();

                if(idAluno == null) {
                    var newStudent = StudentsFactory.Create();

                    commandsFactory.Create("insert into Aluno(nome,dataNascimento,sobrenome) values (@nome, @dataNascimento, @sobrenome)");

                    commandsFactory.AddParam("@nome", newStudent.Name);
                    commandsFactory.AddParam("@dataNascimento", newStudent.BirthDate);
                    command = commandsFactory.AddParam("@sobrenome", newStudent.SurName);
     
                    int alunosCriados = (int)command.ExecuteNonQuery();

                    Console.WriteLine("Alunos criados: " + alunosCriados.ToString());

                    commandsFactory.Create("select codAluno from Aluno where nome=@nome");
               
                    var selectStudent = commandsFactory.AddParam("@nome", newStudent.Name);
                
                    int idNovoAluno = (int)selectStudent.ExecuteScalar();

                    var telephonesFactory = new TelephonesFactory();

                    telephonesFactory.PopulateNames();

                    var insertPhones = "insert into Telefone(codAluno,tipo,telefone) values";

                    telephonesFactory.CreateParameters(insertPhones);
                   
                    commandsFactory.Create(insertPhones);

                    commandsFactory.AddParam("@codAluno", Convert.ToString(idNovoAluno));

                    var insertTel = telephonesFactory.InjectParameters(commandsFactory);

                    insertTel.ExecuteNonQuery();
                    System.Console.WriteLine("Aluno criado!");
                } else {
                    string queryStringTelefone = "select * from Telefone where codAluno=@cod";
                    SqlCommand comandoTelfone = new SqlCommand(queryStringTelefone, connection);
                    comandoTelfone.Parameters.Add(new SqlParameter("@cod",idAluno));

                    SqlDataReader leitor = comandoTelfone.ExecuteReader();

                    while(leitor.Read()) {
                        System.Console.WriteLine(leitor[3]);
                    }
                }
                           
                connection.Close();
            } catch (Exception e){
                Console.WriteLine("Problemas para estabelecer a conexão!");
                Console.WriteLine(e);
            } finally {
                if ( connection != null )
                    connection.Close();
            }
        }
    }
}

