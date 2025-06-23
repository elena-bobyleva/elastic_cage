using Model.Enums;
using Model.Menu.Elements;
using Model.Records;

namespace Model.Game
{
  /// <summary>
  /// Окно окончания игры
  /// </summary>
  public class EndGame : ScreenMenu
  {
    /// <summary>
    /// Имя игрока
    /// </summary>
    public string PlayerName { get; set; }

    /// <summary>
    /// Счет
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EndGame() : base()
    {
      PlayerName = "";
      DeleteLabels();
      AddLabelElement(new LabelElement(Properties.Resources.EndGame));
      AddLabelElement(new LabelElement(Properties.Resources.Score));
      AddLabelElement(new LabelElement(Properties.Resources.NameUser));
      AddTextBoxElement(new TextBoxElement());
      //AddButtonElement(new ButtonElement((int)MenuItemCodes.NewGame, Properties.Resources.Game));
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Menu, Properties.Resources.MainMenu));
      FocusButtonByNumber((int)MenuItemCodes.Menu);
    }

    /// <summary>
    /// Добавление символа
    /// </summary>
    /// <param name="parSymbol">символ(код символа)</param>
    public void AddSymbol(int parSymbol)
    {
      TextBoxs[0].Text += (char)parSymbol;
      TextBoxs[0].ChangeText(TextBoxs[0].Text);
    }

    /// <summary>
    /// Удаление последнего символ
    /// </summary>
    public void RemoveSymbol()
    {
      //if (TextBoxs[0].Text.Length >0)
      {
        TextBoxs[0].ChangeText(TextBoxs[0].Text.Remove(TextBoxs[0].Text.Length - 1));
      }

    }

    /// <summary>
    /// Сохранение рекорд в файл
    /// </summary>
    public void SaveRecord()
    {
      if (TextBoxs[0].Text.Length == 0)
      {
        PlayerName = $"НЕИЗВЕСТНЫЙ";
      }
      else
      {
        PlayerName = TextBoxs[0].Text;
      }

      string record = $"{PlayerName} - {Score}\n";
      RecordsFile.WriteRecords(Properties.Resources.RecordsFile, record);
    }

  }
}
