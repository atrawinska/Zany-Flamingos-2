
using e_learning_application.Views;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.ComponentModel;

namespace e_learning_application.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private UserControl currentView;

    private readonly MainInsideView insideView = new MainInsideView{DataContext=new MainInsideView()};
   

       public MainWindowViewModel() 
    {
        currentView = insideView;
    }

}
