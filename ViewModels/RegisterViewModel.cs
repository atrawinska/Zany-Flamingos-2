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

    
    [ObservableProperty]
    private string message; // For holding the error message

    [ObservableProperty]
    private bool isMessageVisible; // For controlling visibility of the error message

    private readonly MainWindowViewModel _mainWindowViewModel;

    public RegisterViewModel(MainWindowViewModel mainWindowViewModel, string type)
    {
        Type = type;
        _mainWindowViewModel = mainWindowViewModel;
        HideError();
        HideMessage();

    }

    [RelayCommand]
    private void Register()
    {
        HideError();
        Debug.Write("To the registration and its json reader type:" +Type +"was passed.");
        jsonReader = new(Type);

    if (IsUsernameTaken())
    {
        PrintMessage("Username is already taken!");
        return;
    }

        
        

        if(Type == "Student"){

             Student user = new Student(username, PasswordHasher.HashPassword(password), name );
             _mainWindowViewModel.allStudents.Add(user);
                jsonReader.SaveData(_mainWindowViewModel.allStudents);
                 Debug.WriteLine("Registered a new "+ Type);
                PrintMessage("Registered. Now please go back to the main screen and log in.");


        }
        else if(Type == "Teacher"){

             Teacher user = new Teacher(username, password, name);
                          _mainWindowViewModel.allTeachers.Add(user);
                jsonReader.SaveData(_mainWindowViewModel.allTeachers);
             
                Debug.WriteLine("Registered a new "+ Type);
                PrintMessage("Registered. Now please go back to the main screen and log in.");

        }

   



    }



    [RelayCommand]
    private void Back()
    {
        _mainWindowViewModel.GoToRoleSelection();
    }


   private bool IsUsernameTaken()
    {
        bool isUsernameTaken = false;

        if (Type == "Student")
        {
            isUsernameTaken = _mainWindowViewModel.allStudents.Any(s => s.Username == Username);
        }
        else if (Type == "Teacher")
        {
            isUsernameTaken = _mainWindowViewModel.allTeachers.Any(t => t.Username == Username);
        }

        return isUsernameTaken;
    }
private void PrintMessage(string message)
{
    Message = message;
    IsMessageVisible = true;
}

private void PrintError(string message)
{
    ErrorMessage = message;
    IsErrorVisible = true;
}
private void HideMessage()
{
    Message = "";
    IsMessageVisible = false;
}
private void HideError()
{
    ErrorMessage = "";
    IsErrorVisible = false;
}


    

}

