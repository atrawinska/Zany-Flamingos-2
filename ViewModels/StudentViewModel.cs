using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Views;
using System.Diagnostics;

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

    public StudentViewModel(MainWindowViewModel mainWindowViewModel)
    {
        _mainWindowViewModel = mainWindowViewModel;

        Subjects = new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };


        EnrolledSubjects = new ObservableCollection<Subject>
            {
                new Subject(name: "Polish"),
                new Subject(name: "Science")
            };





    }


    public StudentViewModel(MainWindowViewModel mainWindowViewModel, ObservableCollection<Subject> _subjects)
    {

        Subjects = _subjects;

        _mainWindowViewModel = mainWindowViewModel;





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
        Debug.WriteLine("List clciked");
        
        if(SelectedSubject is not null){

       EnrolledSubjects.Add(SelectedSubject);
      // Subjects.Remove(SelectedSubject);

        }
    }

        [RelayCommand]
    private void RemoveSubject()
    {
        Debug.WriteLine("List clciked");
        
        if(SelectedMySubject is not null){

       EnrolledSubjects.Remove(SelectedMySubject);
      // Subjects.Remove(SelectedSubject);

        }
    }



}