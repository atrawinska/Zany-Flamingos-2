﻿using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
        public Dictionary<string, Student> allStudentsMap { get; private set; } = new Dictionary<string, Student>();
        public List<Teacher> allTeachers;
        public Dictionary<string, Teacher> allTeachersMap { get; private set; } = new Dictionary<string, Teacher>();
        public List<Subject> allSubjects;



        public Student CurrentStudent { get; set; }
        public Teacher CurrentTeacher { get; set; }



        [ObservableProperty]
        private UserControl currentView;

        public MainWindowViewModel()
        {
            // Start with role selection screen
          

            JsonReader studentReader = new("Student");
            JsonReader teacherReader = new("Teacher");
            JsonReader subjectReader = new("Subject");

            allStudents = studentReader.ReadData<Student>();
            allTeachers = teacherReader.ReadData<Teacher>();
            allSubjects = subjectReader.ReadData<Subject>();

            allStudentsMap = allStudents.ToDictionary(s => s.Username, s => s);
            allTeachersMap = allTeachers.ToDictionary(t => t.Username, t => t);

              CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };

            

        }


        public void SwitchToLoginView(string role)
        {
            var loginViewModel = new LoginViewModel(role, this);
            CurrentView = new LoginView { DataContext = loginViewModel };
        }

        public void SwitchToStudentView(Student student)
        {
            CurrentView = new StudentView { DataContext = new StudentViewModel(this, student) };
        }

        public void SwitchToTeacherView(Teacher teacher)
        {
            CurrentView = new TeacherView { DataContext = new TeacherViewModel(this, teacher) };
        }


        public void GoToRoleSelection()
        {

            CurrentView = new RoleSelectionView { DataContext = new RoleSelectionViewModel(this) };

        }



        public void GoToRegister(string type)
        {

            CurrentView = new RegisterView { DataContext = new RegisterViewModel(this, type) };

        }


        public void AddSubject(Subject newSubject)
        {

            JsonReader subjectReader = new("Subject");

            allSubjects.Add(newSubject);
            subjectReader.SaveData(allSubjects);
            SaveAll();


        }

        public void RemoveSubject(Subject badSubject)
        {


            JsonReader subjectReader = new("Subject");
            allSubjects.Remove(badSubject);
            subjectReader.SaveData(allSubjects);

        }

        public void SaveAll()
        {
            JsonReader studentReader = new("Student");
            JsonReader teacherReader = new("Teacher");
            JsonReader subjectReader = new("Subject");
            subjectReader.SaveData(allSubjects);
            teacherReader.SaveData(allTeachers);
            studentReader.SaveData(allStudents);
        }


    }
}
