using System.Collections.Generic;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Avalonia.Controls;
using CommunityToolkit.Mvvm.Input;
using e_learning_application.Views;
using e_learning_application.Models;
using System.Diagnostics;
using System;
using System.Linq;

namespace e_learning_application.ViewModels;

public partial class TeacherViewModel : ObservableObject
{
    [ObservableProperty]
    private Subject? selectedSubject;

    private Teacher currentTeacher;

    private readonly MainWindowViewModel _mainWindowViewModel;

    [ObservableProperty]
    private string role = "Teacher";

    [ObservableProperty]
    private ObservableCollection<Subject> mySubjects; // Subjects created by the teacher

    // Pass the Teacher object into the constructor to avoid null issues
    public TeacherViewModel(MainWindowViewModel mainWindowViewModel, Teacher teacher)
    {
        _mainWindowViewModel = mainWindowViewModel;
        currentTeacher = teacher;

        MySubjects = new();


        foreach( var sub in mainWindowViewModel.allSubjects){

            if(sub.TeacherId == currentTeacher.Id){
                MySubjects.Add(sub);

            }
        }


      




        Debug.WriteLine($"Teacher {teacher.Name} loaded with {MySubjects.Count} subjects.");
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
        if (string.IsNullOrWhiteSpace(SubjectName) || string.IsNullOrWhiteSpace(SubjectDescription))
        {
            Debug.WriteLine("Cannot add subject with empty name or description.");
            return;
        }

        // Create new subject
        Subject newSubject = new()
        {
            Id = new Random().Next(100000, 999999), // Generate a random unique ID
            Name = SubjectName,
            Description = SubjectDescription,
            TeacherId = currentTeacher.Id
        };

        // 🔹 Add subject to teacher's collection

        MySubjects.Add(newSubject); // UI updates automatically

        // 🔹 Add to main subject list
        _mainWindowViewModel.AddSubject(newSubject);

        Debug.WriteLine($"Added subject {newSubject.Name} to {currentTeacher.Name}");
    }

    [RelayCommand]
    private void RemoveSubject()
    {
        if (SelectedSubject != null)
        {
            MySubjects.Remove(SelectedSubject);
            _mainWindowViewModel.RemoveSubject(SelectedSubject);

            Debug.WriteLine($"Removed subject {SelectedSubject.Name} from {currentTeacher.Name}");
        }
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
        if (SelectedSubject != null)
        {
            DisplayVisible = true;
            SubjectNameDisplay = SelectedSubject.Name;
            SubjectDescriptionDisplay = SelectedSubject.Description;
        }
    }
}
