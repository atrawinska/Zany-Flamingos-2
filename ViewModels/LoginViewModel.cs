using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Models;

namespace e_learning_application.ViewModels;

public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        public IRelayCommand LoginCommand { get; }

        private readonly string studentUsername = "student";
        private readonly string studentPassword = "password";
        private readonly string teacherUsername = "teacher";
        private readonly string teacherPassword = "password";

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
        }

        private void Login()
        {
            if (username == studentUsername && password == studentPassword)
            {
                // Switch to student view
                MainWindowViewModel.Instance.SwitchToStudentView();
            }
            else if (username == teacherUsername && password == teacherPassword)
            {
                // Switch to teacher view
                MainWindowViewModel.Instance.SwitchToTeacherView();
            }
            else
            {
                // Show error message
                // Example: MessageBox.Show("Invalid credentials");
            }
        }
    }