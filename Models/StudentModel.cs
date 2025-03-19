using System;
using System.Collections.Generic;

namespace e_learning_application.Models
{
    public class Student : IUser
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public int Id { get; set; } // Unique identifier for the student
        public string Name { get; set; } // Full name of the student
        public List<Subject> EnrolledSubjects { get; set; } = new List<Subject>();


        public Student()
        {
        }
        public Student( string username, string password, string name)
        {
            Id =  (int)DateTime.UtcNow.Ticks; 
            Username = username;
            Password = password;
            Name = name;
            EnrolledSubjects = new List<Subject>(); // Ensures it's never null
        }

                public Student(int id, string username, string password, string name, List<Subject> enrolledSubjects = null)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            EnrolledSubjects = enrolledSubjects ?? new List<Subject>(); // Ensures it's never null
        }





    }
}
