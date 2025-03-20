using System;
using System.Collections.Generic;
using System.Diagnostics;

public class Subject
{
    public int Id { get; set; }  // Unique identifier for the subject
    public string Name { get; set; }  // Subject name
    public string Description { get; set; }  // Brief details about the subject
    public int TeacherId { get; set; }  // ID of the teacher who created the subject
    public List<int> StudentsEnrolled { get; set; } = new List<int>();  // List of student IDs enrolled in the subject


    /// <summary>
    /// Used for initalization.
    /// </summary>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="teacherId"></param>
    /// <param name="studentsEnrolled"></param>
    public Subject(string name = null, string description = null, int teacherId = 0, List<int> studentsEnrolled = null)
    {
        Id = (int)DateTime.UtcNow.Ticks;  // Unique identifier based on UTC ticks

        // Optional parameters assignment with null checks
        Name = name ?? "Unnamed Subject";  // Default to "Unnamed Subject" if no name is provided
        Description = description ?? "No description available";  // Default to "No description available" if no description is provided
        TeacherId = teacherId > 0 ? teacherId : 1;  // Default to teacher ID 1 if none provided
        StudentsEnrolled = studentsEnrolled ?? new List<int>();  // Default to an empty list if no students are provided

        Debug.WriteLine("New subject created, id: " + Id);
    }

    /// <summary>
    /// Used for reinitialization.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="description"></param>
    /// <param name="teacherId"></param>
    /// <param name="studentsEnrolled"></param>
    public Subject(int id, string name = null, string description = null, int teacherId = 0, List<int> studentsEnrolled = null)
    {
        Id = id;

        // Optional parameters assignment with null checks
        Name = name ?? "Unnamed Subject";  // Default to "Unnamed Subject" if no name is provided
        Description = description ?? "No description available";  // Default to "No description available" if no description is provided
        TeacherId = teacherId > 0 ? teacherId : 1;  // Default to teacher ID 1 if none provided
        StudentsEnrolled = studentsEnrolled ?? new List<int>();  // Default to an empty list if no students are provided

        Debug.WriteLine("New subject created, id: " + Id);
    }

    public Subject(){}


    /// <summary>
    /// Overrides tostring() method so it displays well in the lisboxes.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        return Name;
    }

}