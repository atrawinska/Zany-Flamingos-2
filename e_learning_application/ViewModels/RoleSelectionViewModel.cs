using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace e_learning_application.ViewModels
{
    public partial class RoleSelectionViewModel : ObservableObject
    {
        private readonly MainWindowViewModel _mainWindowViewModel;

        public RoleSelectionViewModel(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }

        [RelayCommand]
        private void SelectStudent()
        {
            _mainWindowViewModel.SwitchToLoginView("Student");
        }

        [RelayCommand]
        private void SelectTeacher()
        {
            _mainWindowViewModel.SwitchToLoginView("Teacher");
        }

        
    }
}
