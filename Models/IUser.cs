using System.Collections.Generic;

namespace e_learning_application.Models
{
    public interface IUser
    {
        string Username { get; set; }
        string Password { get; set; }
        int Id { get; set; } // Unique identifier
        string Name { get; set; } // Full name
     
    }
}