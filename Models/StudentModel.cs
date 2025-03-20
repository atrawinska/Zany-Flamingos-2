using System;
using System.Collections.Generic;

namespace e_learning_application.Models
{
    public class Student
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int Id { get; set; } // Unique identifier for the student
        public string Name { get; set; } // Full name of the student
        public List<int> EnrolledSubjects { get; set; } = new List<int>();


        public Student()
        {
        }
        public Student( string username, string password, string name)
        {
            Id =  (int)DateTime.UtcNow.Ticks; 
            Username = username;
            Password = password;
            Name = name;





            EnrolledSubjects = new List<int>(); // Ensures it's never null
        }

                public Student(int id, string username, string password, string name, List<int> enrolledSubjects = null)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            EnrolledSubjects = enrolledSubjects ?? new List<int>(); // Ensures it's never null
        }





    }
}
