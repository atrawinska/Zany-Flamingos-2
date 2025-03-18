using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace e_learning_application.ViewModels
{
    public partial class RoleSelectionViewModel : ObservableObject
    {
        
        public IRelayCommand SelectStudentCommand { get; }
        public IRelayCommand SelectTeacherCommand { get; }

        public RoleSelectionViewModel()
        {
            SelectStudentCommand = new RelayCommand(SelectStudent);
            SelectTeacherCommand = new RelayCommand(SelectTeacher);
        }

        private void SelectStudent()
        {
            // Implement role selection logic here
        }

        private void SelectTeacher()
        {
            // Implement role selection logic here
        }
    }
}