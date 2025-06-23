using Model.Enums;
using Model.Menu.Elements;

namespace Model.Menu
{
  /// <summary>
  /// Главное меню
  /// </summary>
  public class MainMenu : ScreenMenu
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public MainMenu() : base()
    {
      AddLabelElement(new LabelElement(Properties.Resources.ElectricCage));
      AddButtonElement(new ButtonElement((int)MenuItemCodes.NewGame, Properties.Resources.Game));
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Records, Properties.Resources.Records));
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Rule, Properties.Resources.Rule));
      AddButtonElement(new ButtonElement((int)MenuItemCodes.Exit, Properties.Resources.Exit));

      FocusButtonByNumber((int)MenuItemCodes.NewGame);
    }

  }
}
