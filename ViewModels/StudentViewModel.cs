using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace e_learning_application.ViewModels;

public partial class StudentViewModel : ObservableObject
{

    // Unique identifier for the student
    public int Id { get; set; }

    // Full name of the student
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }




[ObservableProperty]
private string role = "Student";


[ObservableProperty]
private ObservableCollection<Subject> subjects;


[ObservableProperty]
private ObservableCollection<Subject> enrolledSubjects;

public StudentViewModel( ){

    Subjects = new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };


    EnrolledSubjects = new ObservableCollection<Subject>
            {
                new Subject(name: "Math"),
                new Subject(name: "Science")
            };


     


}


public StudentViewModel( ObservableCollection<Subject> _subjects){

    Subjects = _subjects;
    EnrolledSubjects.Clear();


     


}

public StudentViewModel(int id, string name, string username, string password,ObservableCollection<Subject> _subjects, ObservableCollection<Subject> _enrolledSubjects){

    Subjects = _subjects;
    EnrolledSubjects = _enrolledSubjects;


     


}
public StudentViewModel(int id, string name, string username, string password, ObservableCollection<Subject> _subjects){

    Subjects = _subjects;
    EnrolledSubjects.Clear();


     


}



   
}