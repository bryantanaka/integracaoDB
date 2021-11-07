using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ARMAZENAMENTO.Entities;

namespace ARMAZENAMENTO.Model.Factories
{
    public static class StudentsFactory
    {
        static public Student Create()
        {
            Console.WriteLine("Insira o primeiro nome do aluno: ");
            string nome = Console.ReadLine();
            Console.WriteLine("Insira a data de nascimento: ");
            string dataNascimento = Console.ReadLine();
            Console.WriteLine("Insira o sobrenome do aluno: ");
            string sobrenome = Console.ReadLine();

            return new Student(nome, dataNascimento, sobrenome);
        }
    }
}

