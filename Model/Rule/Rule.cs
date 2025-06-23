using Model.Enums;
using Model.Menu.Elements;
using System;
using System.IO;

namespace Model.Rule
{
  /// <summary>
  /// Правила
  /// </summary>
  public class Rule : ScreenMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public Rule() : base()
    {
      AddLabelElement(new LabelElement(Properties.Resources.RuleText));
      AddLabelElement(new LabelElement(""));
      string[] ruleText = GetRule();
      foreach (string elRule in ruleText)
      {
        AddLabelElement(new LabelElement(elRule));
      }
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Menu, Properties.Resources.MainMenu));
      FocusButtonByNumber((int)MenuItemCodes.Menu);
    }

    /// <summary>
    /// Получение правил
    /// </summary>
    /// <returns></returns>
    private string[] GetRule()
    {
      string[] ruleText = new string[13];
      int i = 0;

      if (File.Exists(Properties.Resources.RuleFile))
      {
        try
        {
          using (StreamReader reader = new StreamReader(Properties.Resources.RuleFile))
          {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
              ruleText[i] += line + "\n";
              i++;
            }
          }

        }
        catch (FileNotFoundException e)
        {
          Console.WriteLine(e.Message);
        }
      }

      return ruleText;
    }
  }
}
