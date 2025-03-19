using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Models;
using System.Collections.Generic;
using System.Linq; // Make sure to import LINQ
using e_learning_application.Views;
namespace e_learning_application.ViewModels;
public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        private string username;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private string role;

        [ObservableProperty]
        private string errorMessage; // For holding the error message

        [ObservableProperty]
        private bool isErrorVisible; // For controlling visibility of the error message

        private readonly MainWindowViewModel _mainWindowViewModel;
  
    public RegisterViewModel(MainWindowViewModel mainWindowViewModel)
        {
        
            _mainWindowViewModel = mainWindowViewModel;

        }

        [RelayCommand]
        private void Register()
        {
            
        }



[RelayCommand]
private void Back()
{
    _mainWindowViewModel.GoToRoleSelection();
}

    }
    
