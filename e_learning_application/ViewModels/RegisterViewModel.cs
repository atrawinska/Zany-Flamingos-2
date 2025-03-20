using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Models;
using System.Collections.Generic;
using System.Linq; // Make sure to import LINQ
using e_learning_application.Views;
using System.Diagnostics;
namespace e_learning_application.ViewModels;
public partial class RegisterViewModel : ObservableObject
{

    private JsonReader jsonReader;

    [ObservableProperty]
    private string username;

    [ObservableProperty]
    private string password;

    [ObservableProperty]
    private string name;

    [ObservableProperty]
    private string role;

    private string type;
    public string Type{
        get{ return type;}
        set{

            type = value;

        }
    }

    [ObservableProperty]
    private string errorMessage; // For holding the error message

    [ObservableProperty]
    private bool isErrorVisible; // For controlling visibility of the error message

    private readonly MainWindowViewModel _mainWindowViewModel;

    public RegisterViewModel(MainWindowViewModel mainWindowViewModel, string type)
    {
        Type = type;
        _mainWindowViewModel = mainWindowViewModel;

    }

    [RelayCommand]
    private void Register()
    {
        Debug.Write("To the registration and its json reader type:" +Type +"was passed.");
        jsonReader = new(Type);

        
        

        if(Type == "Student"){

             Student user = new Student(username, password, name );
             _mainWindowViewModel.allStudents.Add(user);
                jsonReader.SaveData(_mainWindowViewModel.allStudents);
                 Debug.WriteLine("Registered a new "+ Type);


        }
        else if(Type == "Teacher"){

             Teacher user = new Teacher(username, password, name);
                          _mainWindowViewModel.allTeachers.Add(user);
                jsonReader.SaveData(_mainWindowViewModel.allTeachers);
             
                Debug.WriteLine("Registered a new "+ Type);

        }

   



    }



    [RelayCommand]
    private void Back()
    {
        _mainWindowViewModel.GoToRoleSelection();
    }

}

