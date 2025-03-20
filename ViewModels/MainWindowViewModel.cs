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
          public List<Subject> allSubjects;

           JsonReader studentReader = new("Student");
           JsonReader teacherReader = new("Teacher");
           JsonReader subjectReader = new("Subject");



        [ObservableProperty]
        private UserControl currentView;

        public MainWindowViewModel()
        {
            // Start with role selection screen
            CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };
            // allStudents = new(); //change to read from json
            // allTeachers = new(); //change to read from json

            
            allStudents = studentReader.ReadData<Student>();             
            allTeachers = teacherReader.ReadData<Teacher>();
            allSubjects = subjectReader.ReadData<Subject>();

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


        public void AddSubject(Subject newSubject){

             allSubjects.Add(newSubject);
             subjectReader.SaveData(allSubjects);


        }

        public void RemoveSubject(Subject badSubject){

            allSubjects.Remove(badSubject);
            subjectReader.SaveData(allSubjects);

        }


    }
}
