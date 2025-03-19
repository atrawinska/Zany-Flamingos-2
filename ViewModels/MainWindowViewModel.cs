using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Views;

namespace e_learning_application.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private UserControl currentView;

        public MainWindowViewModel()
        {
            // Start with role selection screen
            CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };
        }

        public void SwitchToLoginView(string role)
        {
            var loginViewModel = new LoginViewModel(role, this);
            CurrentView = new LoginView { DataContext = loginViewModel };
        }

        public void SwitchToStudentView()
        {
            CurrentView = new StudentView { DataContext = new StudentViewModel(this) };
        }

        public void SwitchToTeacherView()
        {
            CurrentView = new TeacherView { DataContext = new TeacherViewModel(this) };
        }


        public void GoToRoleSelection(){

            CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };

        }

       

         public void  GoToRegister(){

            CurrentView = new RegisterView{ DataContext = new RegisterViewModel(this) };

        }


    }
}
