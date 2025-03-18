using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;


namespace e_learning_application.ViewModels
{
    public partial class RoleSelectionViewModel : ObservableObject
    {
        private readonly MainWindowViewModel _mainViewModel;

        public RoleSelectionViewModel(MainWindowViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }

        [RelayCommand]
        private void SelectStudent()
        {
            _mainViewModel.SwitchToStudentView(); // Switch to Student View
        }

        [RelayCommand]
        private void SelectTeacher()
        {
            _mainViewModel.SwitchToTeacherView(); // Switch to Teacher View
        }
    }
}
