using System.Collections.Generic;
using System;

namespace e_learning_application.Models;
    public class Teacher  : IUser
    {
    public int Id { get; set; }

    // Full name 
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }
    public List<Subject> MySubjects { get; set; } = new List<Subject>();  // List of subject the teacher created


public Teacher(){}


        public Teacher( string username, string password, string name)
        {
            Id =  (int)DateTime.UtcNow.Ticks; 
            Username = username;
            Password = password;
            Name = name;
            MySubjects = new List<Subject>(); // Ensures it's never null
        }

        public Teacher(int id, string username, string password, string name, List<Subject> enrolledSubjects = null)
        {
            Id = id;
            Username = username;
            Password = password;
            Name = name;
            MySubjects = enrolledSubjects ?? new List<Subject>(); // Ensures it's never null
        }




    



    }

