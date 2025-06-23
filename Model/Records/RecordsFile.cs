using System;
using System.Collections.Generic;
using System.IO;

namespace Model.Records
{
  /// <summary>
  /// Работа с файлом рекордов
  /// </summary>
  public class RecordsFile
  {
    /// <summary>
    /// Запись рекордов
    /// </summary>
    /// <param name="parFileName">имя файла</param>
    /// <param name="parText">текст</param>
    public static void WriteRecords(string parFileName, string parText)
    {
      File.AppendAllText(parFileName, parText);
    }

    /// <summary>
    /// Чтение рекордов из файла
    /// </summary>
    /// <param name="parFileName">имя файла</param>
    /// <returns>возвращает список рекордов</returns>
    public static List<Tuple<string, int>> ReadRecords(string parFileName)
    {
      List<Tuple<string, int>> fileContent = new List<Tuple<string, int>>();

      if (File.Exists(parFileName))
      {
        try
        {
          using (StreamReader reader = new StreamReader(parFileName))
          {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
              string[] records = line.Split(' ');
              fileContent.Add(new Tuple<string, int>(records[0], int.Parse(records[2])));
            }
          }

        }
        catch (FileNotFoundException ex)
        {
          Console.WriteLine(ex.Message);
        }
      }

      return fileContent;
    }
  }
}
