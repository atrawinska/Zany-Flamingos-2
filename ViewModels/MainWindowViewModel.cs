
using e_learning_application.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;

namespace e_learning_application.ViewModels;

    public partial class MainWindowViewModel : ViewModelBase
    {
        private static MainWindowViewModel instance;
        public static MainWindowViewModel Instance => instance ??= new MainWindowViewModel();

        [ObservableProperty]
        private UserControl currentView;

        private readonly RoleSelectionView roleSelectionView = new RoleSelectionView { DataContext = new RoleSelectionViewModel() };
        private readonly MainInsideView insideView = new MainInsideView { DataContext = new MainInsideView() };
        private readonly StudentInsideView studentInsideView = new StudentInsideView { DataContext = new StudentInsideViewModel() };
        private readonly TeacherInsideView teacherInsideView = new TeacherInsideView { DataContext = new TeacherInsideViewModel() };

        public MainWindowViewModel()
        {
            currentView = roleSelectionView;
        }

        public void SwitchToInsideView()
        {
            currentView = insideView;
        }

        public void SwitchToRoleSelectionView()
        {
            currentView = roleSelectionView;
        }

        public void SwitchToStudentView()
        {
            currentView = studentInsideView;
        }

        public void SwitchToTeacherView()
        {
            currentView = teacherInsideView;
        }

        public void SwitchToLoginView()
        {
            currentView = new LoginView { DataContext = new LoginViewModel() };
        }
    }