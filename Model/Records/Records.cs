using Model.Enums;
using Model.Menu.Elements;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Records
{
  /// <summary>
  /// Рекорды
  /// </summary>
  public class Records : ScreenMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public Records() : base()
    {
      GetRecords();
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Menu, Properties.Resources.MainMenu));
      FocusButtonByNumber((int)MenuItemCodes.Menu);
    }

    /// <summary>
    /// Получение таблицы с рекордами
    /// </summary>
    public void GetRecords()
    {
      DeleteLabels();
      AddLabelElement(new LabelElement(Properties.Resources.RecordsText));
      AddLabelElement(new LabelElement(""));
      List<Tuple<string, int>> recordsData = RecordsFile.ReadRecords(Properties.Resources.RecordsFile).OrderByDescending(x => x.Item2).ToList();

      if (recordsData.Count != 0)
      {
        //AddLabelElement(new LabelElement($"┌−−−−−−−−−−−−−−−−−−┬−−−−−−−−−−−−−−−−┐"));
        //AddLabelElement(new LabelElement($"│Имя игрока        │Количество очков│"));
        //AddLabelElement(new LabelElement($"├−−−−−−−−−−−−−−−−−−┼−−−−−−−−−−−−−−−−┤"));
        AddLabelElement(new LabelElement($"Имя игрока              Количество очков"));
        if (recordsData.Count > 3)
        {
          for (int i = 0; i < 3; i++)
          {
            string name = recordsData[i].Item1;
            string score = recordsData[i].Item2.ToString();
            AddLabelElement(new LabelElement($"{name,-19}  {score,-18}"));
          }
        }
        else
        {
          for (int i = 0; i < recordsData.Count; i++)
          {
            string name = recordsData[i].Item1;
            string score = recordsData[i].Item2.ToString();
            AddLabelElement(new LabelElement($"{name,-19}  {score,-18}"));
          }
        }
        //AddLabelElement(new LabelElement($"└−−−−−−−−−−−−−−−−−−┴−−−−−−−−−−−−−−−−┘"));
      }
    }
  }
}
