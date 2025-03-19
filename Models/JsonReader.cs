using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;


namespace e_learning_application.Models;

public class JsonReader{


     private readonly string _filePath;



     public T ReadData<T>()
    {
        try
        {
            if (File.Exists(_filePath))
            {
                string jsonString = File.ReadAllText(_filePath);
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.IgnoreCycles
                };

                return JsonSerializer.Deserialize<T>(jsonString, options);
            }
            else
            {
                Debug.WriteLine("File not found. Returning default.");
                return default; // Or initialize with a default value
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Error reading data: {ex.Message}");
            return default;
        }
    }//read data



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






}