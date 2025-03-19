using System.Collections.Generic;

namespace e_learning_application.Models;
    public class Teacher
    {
    public int Id { get; set; }

    // Full name 
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }
    public List<Subject> MySubjects { get; set; } = new List<Subject>();  // List of subject the teacher created




    



    }

