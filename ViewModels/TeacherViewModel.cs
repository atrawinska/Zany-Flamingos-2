using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
namespace e_learning_application.ViewModels;

public partial class TeacherViewModel : ObservableObject
{

    public int Id { get; set; }

    // Full name 
    public string Name { get; set; }

    // Username for authentication
    public string Username { get; set; }

    // Password for authentication
    public string Password { get; set; }




    [ObservableProperty]
private string role = "Teacher";


    [ObservableProperty]
    private ObservableCollection<Subject> mySubjects; //subjects the teacher has created

        [ObservableProperty]
    private ObservableCollection<Subject> subjects; //subjects the teacher has created





public TeacherViewModel( ){

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


public TeacherViewModel( ObservableCollection<Subject> _subjects){

    MySubjects = _subjects;




}


   
}