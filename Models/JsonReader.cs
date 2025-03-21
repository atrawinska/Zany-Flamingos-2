using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace e_learning_application.Models;

public class JsonReader{


private string _filePath = ""; // Name of your JSON file
private string studentPath = "student.json"; 
private string teacherPath = "teacher.json";
private string subjectPath = "subject.json"; 


public JsonReader(string type)
{
    // Get the project's root directory (two levels up)
    string projectRoot = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\.."));

    // Define a 'data' folder inside the project root
    string dataFolder = Path.Combine(projectRoot, "data");

    // Ensure the 'data' directory exists
    Directory.CreateDirectory(dataFolder);

    // Set the correct file path based on the type
    if (type == "Student")
    {
        Debug.WriteLine("JsonReader chose " + type);
        _filePath = Path.Combine(dataFolder, studentPath);
    }
    else if (type == "Teacher")
    {
        Debug.WriteLine("JsonReader chose " + type);
        _filePath = Path.Combine(dataFolder, teacherPath);
    }
    else if (type == "Subject")
    {
        Debug.WriteLine("JsonReader chose " + type);
        _filePath = Path.Combine(dataFolder, subjectPath);
    }
    else
    {
        Debug.WriteLine("Invalid type (JsonReader)");
        return;
    }

    EnsureFileExists();
}


/// <summary>
/// Function to read the list of data.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <returns>List of objects of type T</returns>
public List<T> ReadData<T>()
{
    try
    {
        if (File.Exists(_filePath))
        {
            string jsonString = File.ReadAllText(_filePath);

            if (string.IsNullOrWhiteSpace(jsonString)) 
            {
                return new List<T>(); // Return an empty list if the file is empty
            }

            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.IgnoreCycles
            };

            return JsonSerializer.Deserialize<List<T>>(jsonString, options) ?? new List<T>();
        }
        else
        {
            Debug.WriteLine("File not found. Returning empty list.");
            return new List<T>(); // Return an empty list if the file doesn't exist
        }
    }
    catch (Exception ex)
    {
        Debug.WriteLine($"Error reading data: {ex.Message}");
        return new List<T>(); // Return an empty list in case of an error
    }
}

/// <summary>
/// Function to save the data.
/// </summary>
/// <typeparam name="T"></typeparam>
/// <returns></returns>
      public void SaveData<T>(T data)
    {
        try
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.IgnoreCycles // Important for avoiding circular references.
            };

            string jsonString = JsonSerializer.Serialize(data, options);
            File.WriteAllText(_filePath, jsonString);
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error saving data: {ex.Message}");
        }
    }



    /// <summary>
    /// Ensures that the file exists, creating it with an empty array if missing.
    /// </summary>
    private void EnsureFileExists()
    {
        if (!File.Exists(_filePath))
        {
            Debug.WriteLine($"File {_filePath} does not exist. Creating a new one...");
            File.WriteAllText(_filePath, "[]"); // Initializes with an empty JSON array
        }
    }





}