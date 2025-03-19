using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Models;
using e_learning_application.Views;

namespace e_learning_application.ViewModels
{
    public partial class MainWindowViewModel : ObservableObject
    {
        public List<Student> allStudents;
          public List<Teacher> allTeachers;


        [ObservableProperty]
        private UserControl currentView;

        public MainWindowViewModel()
        {
            // Start with role selection screen
            CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };
            // allStudents = new(); //change to read from json
            // allTeachers = new(); //change to read from json

            JsonReader studentReader = new("Student");
            allStudents = studentReader.ReadData<Student>();

             JsonReader teacherReader = new("Teacher");
            allTeachers = teacherReader.ReadData<Teacher>();
            foreach(Student x in allStudents){
                Debug.WriteLine(x.Name);}
            foreach(Teacher x in allTeachers){
            Debug.WriteLine(x.Name);}

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

       

         public void  GoToRegister(string type){

            CurrentView = new RegisterView{ DataContext = new RegisterViewModel(this, type)};

        }


    }
}
