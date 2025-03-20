using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Views;

namespace e_learning_application.ViewModels;

public partial class TeacherViewModel : ObservableObject
{

[ObservableProperty]
    private Subject? selectedSubject;

    public int Id { get; set; }

    
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }

     private readonly MainWindowViewModel _mainWindowViewModel;



    [ObservableProperty]
private string role = "Teacher";


    [ObservableProperty]
    private ObservableCollection<Subject> mySubjects; //subjects the teacher has created

        [ObservableProperty]
    private ObservableCollection<Subject> subjects; //subjects the teacher has created





public TeacherViewModel( MainWindowViewModel mainWindowViewModel ){
    _mainWindowViewModel = mainWindowViewModel;

    MySubjects =new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };
    Subjects =new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };




}


public TeacherViewModel( MainWindowViewModel mainWindowViewModel,  ObservableCollection<Subject> _subjects){
    _mainWindowViewModel = mainWindowViewModel;
    MySubjects = _subjects;




}



[RelayCommand]
private void Back()
{
    _mainWindowViewModel.GoToRoleSelection();
}


    [ObservableProperty]

    private string subjectName;



        [ObservableProperty]
    private string subjectDescription;


[RelayCommand]
private void AddSubject()
{
    Subject newSubject = new(name: SubjectName, description: SubjectDescription);
    mySubjects.Add(newSubject);
   _mainWindowViewModel.AddSubject(newSubject);
}

[RelayCommand]
private void RemoveSubject()
{
    
    mySubjects.Remove(SelectedSubject);
    _mainWindowViewModel.RemoveSubject(SelectedSubject);
}
    


[ObservableProperty]
private bool displayVisible = false;

    [ObservableProperty]

    private string subjectNameDisplay;



        [ObservableProperty]
    private string subjectDescriptionDisplay;


[RelayCommand]
private void DisplaySubject()
{
    
   DisplayVisible = true;
   SubjectNameDisplay = SelectedSubject.Name;
   SubjectDescriptionDisplay = SelectedSubject.Description;
}



   
}