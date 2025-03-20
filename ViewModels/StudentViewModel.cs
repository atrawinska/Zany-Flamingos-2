using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Views;
using System.Diagnostics;
using e_learning_application.Models;

namespace e_learning_application.ViewModels;

public partial class StudentViewModel : ObservableObject
{

    [ObservableProperty]
    private Subject? selectedSubject;

    [ObservableProperty]
    private Subject? selectedMySubject;

    // Unique identifier for the student
    public int Id { get; set; }

    // Full name of the student
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }

    private readonly MainWindowViewModel _mainWindowViewModel;




    [ObservableProperty]
    private string role = "Student";


    [ObservableProperty]
    private ObservableCollection<Subject> subjects;


    [ObservableProperty]
    private ObservableCollection<Subject> enrolledSubjects;


    Student currentStudent;

    public StudentViewModel(MainWindowViewModel mainWindowViewModel, Student student)
    {
        _mainWindowViewModel = mainWindowViewModel;
    //INSTEAD of assigning lists, do this because it is an observable collection
       Subjects = new ObservableCollection<Subject>(mainWindowViewModel.allSubjects);
       currentStudent = student;

       EnrolledSubjects = new();


 if (currentStudent.EnrolledSubjects != null)
    {
        foreach (var num in currentStudent.EnrolledSubjects)
        {
            foreach (var sub in Subjects)
            {
                if (sub.Id == num)
                {
                    EnrolledSubjects.Add(sub);
                }
            }
        }
    }
    
    Debug.WriteLine($"Loaded {EnrolledSubjects.Count} enrolled subjects for student {currentStudent.Name}.");



       }





    


    public StudentViewModel(MainWindowViewModel mainWindowViewModel, int id, string name, string username, string password, ObservableCollection<Subject> _subjects, ObservableCollection<Subject> _enrolledSubjects)
    {

        Subjects = _subjects;
        EnrolledSubjects = _enrolledSubjects;
        _mainWindowViewModel = mainWindowViewModel;





    }
    public StudentViewModel(MainWindowViewModel mainWindowViewModel, int id, string name, string username, string password, ObservableCollection<Subject> _subjects)
    {

        Subjects = _subjects;
        // EnrolledSubjects.Clear();
        _mainWindowViewModel = mainWindowViewModel;





    }



    [RelayCommand]
    private void Back()
    {
        _mainWindowViewModel.GoToRoleSelection();
    }

    [RelayCommand]
    private void AddSubject()
    {
        Debug.WriteLine("List clciked: " + SelectedSubject.Name);

        if (SelectedSubject is not null)
        {

            EnrolledSubjects.Add(SelectedSubject);
            currentStudent.EnrolledSubjects.Add(SelectedSubject.Id);
            _mainWindowViewModel.SaveAll();
            // Subjects.Remove(SelectedSubject);

        }
    }

    [RelayCommand]
    private void RemoveSubject()
    {
        Debug.WriteLine("List clciked");

        if (SelectedMySubject is not null)
        {

            EnrolledSubjects.Remove(SelectedMySubject);
            // Subjects.Remove(SelectedSubject);
             currentStudent.EnrolledSubjects.Remove(SelectedSubject.Id);
            _mainWindowViewModel.SaveAll();

        }

    }



}