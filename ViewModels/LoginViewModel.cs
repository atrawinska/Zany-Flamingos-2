using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace e_learning_application.ViewModels
{
    public partial class LoginViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string role;

        private readonly MainWindowViewModel _mainWindowViewModel;

        public LoginViewModel(string role, MainWindowViewModel mainWindowViewModel)
        {
            Role = role;
            _mainWindowViewModel = mainWindowViewModel;
        }

        [RelayCommand]
        private void Login()
        {
            if (Role == "Student" && Username == "student" && Password == "password")
            {
                _mainWindowViewModel.SwitchToStudentView();
            }
            else if (Role == "Teacher" && Username == "teacher" && Password == "password")
            {
                _mainWindowViewModel.SwitchToTeacherView();
            }
            else
            {
                // Show error message (can be expanded with UI feedback)
            }
        }
    }
}
