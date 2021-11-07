using System;

namespace ARMAZENAMENTO.Entities
{
    public class Student
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string BirthDate { get; set; }

        public Student(string name, string surName, string birthDate)
        {
            Name = name;
            SurName = surName;
            BirthDate = birthDate;
        }

        
    }
}
