using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using e_learning_application.Views;
using e_learning_application.Models;

namespace e_learning_application.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        // ObservableProperty for Subjects
        [ObservableProperty]
        private ObservableCollection<Subject> subjects = new ObservableCollection<Subject>();

        private static MainWindowViewModel instance;
        public static MainWindowViewModel Instance => instance ??= new MainWindowViewModel();

        // View models for different views
        [ObservableProperty]
        private UserControl currentView;

        private readonly RoleSelectionView roleSelectionView;
        private readonly StudentView studentView;
        private readonly TeacherView teacherView;

        public MainWindowViewModel()
        {
            // Initialize Subjects collection before passing to views
            Subjects = new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };

            // Create views and pass the data context
            roleSelectionView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };
            studentView = new StudentView { DataContext = new StudentViewModel(Subjects) };
            teacherView = new TeacherView { DataContext = new TeacherViewModel( Subjects) };

            // Set initial view
            currentView = roleSelectionView; // Start with RoleSelectionView
        }

        // Switch to different views
        public void SwitchToStudentView()
        {
            CurrentView = studentView;
        }

        public void SwitchToTeacherView()
        {
            CurrentView = teacherView;
        }

    }
}
