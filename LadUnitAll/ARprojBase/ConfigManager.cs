using Autodesk.Revit.DB;
using System;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;

namespace ARprojBase
{
  public class ConfigManager
  {
    public static readonly string dirName = "RevitLAD";
    public static readonly string fileName = "LAD_Settings.xml";

    // Метод для активации конфигурации
    public static T Activate<T>() where T : new()
    {
      T cfg = default;
      string fullPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), dirName, fileName);
      if (File.Exists(fullPath))
      {
        cfg = DeserializeConfig<T>(fullPath);
      }
      if (cfg == null)
      { 
        cfg= new T();
      }
      return cfg;
    }

    // Метод для сохранения конфигурации
    public static bool Save<T>(T config)
    {
      Debug.WriteLine($"Start saving settings...");
      try
      {
        string dirPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), dirName);
        if (!Directory.Exists(dirPath))
        {
          Directory.CreateDirectory(dirPath);
        }

        string filePath = Path.Combine(dirPath, fileName);
        if (File.Exists(filePath))
          File.Delete(filePath);

        SerializeConfig(filePath, config);

        Debug.WriteLine("Save settings success.");
        return true;
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error saving settings: {ex.Message}");
        return false;
      }
    }

    // Метод для десериализации конфигурации из файла
    private static T DeserializeConfig<T>(string fullPath)
    {
      try
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        using (StreamReader streamReader = new StreamReader(fullPath))
        {
          return (T)xmlSerializer.Deserialize(streamReader);
        }
      }
      catch (Exception ex)
      {
        Debug.WriteLine($"Error deserializing config: {ex.Message}");
        return default;
      }
    }

    // Метод для сериализации конфигурации в файл
    private static void SerializeConfig<T>(string filePath, T config)
    {
      using (FileStream fileStream = new FileStream(filePath, FileMode.OpenOrCreate))
      {
        XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
        xmlSerializer.Serialize(fileStream, config);
      }
    }
  }
}