using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Models;
using System.Collections.Generic;
using System.Linq; // Make sure to import LINQ

namespace e_learning_application.ViewModels;
public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string role;

        [ObservableProperty]
        private string errorMessage; // For holding the error message

        [ObservableProperty]
        private bool isErrorVisible; // For controlling visibility of the error message

        private readonly MainWindowViewModel _mainWindowViewModel;

        // Use the Models
        private readonly List<Student> _students = new List<Student>
        {
            new Student { Username = "student", Password = "password" }
        };

        private readonly List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher { Username = "teacher", Password = "password" }
        };

        public LoginViewModel(string role, MainWindowViewModel mainWindowViewModel)
        {
            Role = role;
            _mainWindowViewModel = mainWindowViewModel;

            _students.Add(new Student { Username = "student", Password = "password" });
            _teachers.Add(new Teacher { Username = "teacher", Password = "password" });
        }

        [RelayCommand]
        private void Login()
        {
            bool isValid = false;

            // Validate credentials based on role
            if (Role == "Student")
            {
                var student = _students.FirstOrDefault(s => s.Username == Username && s.Password == Password);
                isValid = student != null;
            }
            else if (Role == "Teacher")
            {
                var teacher = _teachers.FirstOrDefault(t => t.Username == Username && t.Password == Password);
                isValid = teacher != null;
            }

            // Check if login was successful
            if (isValid)
            {
                if (Role == "Student")
                {
                    _mainWindowViewModel.SwitchToStudentView();
                }
                else if (Role == "Teacher")
                {
                    _mainWindowViewModel.SwitchToTeacherView();
                }

                // Hide error message on successful login
                IsErrorVisible = false;
            }
            else
            {
                // Set the error message and make it visible
                ErrorMessage = "Invalid username or password!";
                IsErrorVisible = true;
            }
        }



[RelayCommand]
private void Back()
{
    _mainWindowViewModel.GoToRoleSelection();
}

    }
    
