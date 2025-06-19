// Ignore Spelling: Rproj
using System;
using System.Collections.Generic;
using System.IO;

namespace ARprojBase
{
  public class DocumentFileWriter
  {
    private readonly string _filePath;
    public bool IsEnable { get; set; } = true;

    public DocumentFileWriter(string fileName, bool append = false)
    {
      // Получение пути к папке "Мои документы"
      string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
      _filePath = Path.Combine(documentsPath, fileName);

      // Создание нового файла при инициализации
      CreateNewFile(append);
    }

    private void CreateNewFile(bool append)
    {
      if (!IsEnable) return;
      // Создание нового файла (если файл уже существует, он будет перезаписан)
      using (StreamWriter file = new StreamWriter(_filePath, append)) // false означает, что файл будет перезаписан
      {
        // Можно записать заголовок или оставить файл пустым
        file.WriteLine("Файл создан: " + DateTime.Now);
      }
    }

    public void WriteLines(IEnumerable<string> lines)
    {
      if (lines == null || !IsEnable) return;
      // Открытие файла в режиме добавления
      using (StreamWriter file = new StreamWriter(_filePath, true)) // true означает режим добавления
      {
        foreach (var line in lines)
        {
          file.WriteLine(line);
        }
      }
    }

    // Новый метод для записи одной строки
    public void WriteLine(string line)
    {
      if (!IsEnable) return;
      WriteLines(new List<string> { line }); // Используем WriteLines для добавления строки
    }

    public void ShowFileIfExists()
    {
      if (!IsEnable) return;
      if (File.Exists(_filePath) && new FileInfo(_filePath).Length > 0)
      {
        System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
        {
          FileName = _filePath,
          UseShellExecute = true
        });
      }
    }
  }

}
