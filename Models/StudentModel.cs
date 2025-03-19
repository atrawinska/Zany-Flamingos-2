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






    }
}
