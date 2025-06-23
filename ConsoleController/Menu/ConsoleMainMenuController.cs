using ConsoleView.Menu;
using Controller.Menu;
using Model.Enums;
using Model.Menu.Elements;
using System;
using View.Menu;

namespace ConsoleController.Menu
{
  /// <summary>
  /// Контроллер главного меню
  /// </summary>
  public class ConsoleMainMenuController : MainMenuController
  {
    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    private static ConsoleMainMenuController _controller;

    /// <summary>
    /// Представление окна главного меню
    /// </summary>
    private MainMenuView _viewMenu = null;

    /// <summary>
    /// Состояние работы контроллера
    /// </summary>
    protected bool IsStop { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    private ConsoleMainMenuController() : base()
    {
      Menu = new Model.Menu.MainMenu();
      _viewMenu = new ConsoleMenuView(Menu);
      foreach (ButtonElement elButton in Menu.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера главного меню
    /// </summary>
    /// <returns>контроллер главного меню</returns>
    public static ConsoleMainMenuController GetController()
    {
      if (_controller == null)
      {
        _controller = new ConsoleMainMenuController();
      }

      return _controller;
    }

    /// <summary>
    /// Запуск контроллера главного меню
    /// </summary>
    public override void Start()
    {
      _viewMenu.Draw();
      IsStop = false;
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
          case ConsoleKey.UpArrow:
            Menu.FocusPrevious();
            break;
          case ConsoleKey.DownArrow:
            Menu.FocusNext();
            break;
          case ConsoleKey.Enter:
            Menu.SelectFocusButton();
            break;
        }


      } while (!IsStop);
    }

    /// <summary>
    /// Остановка контроллера главного меню
    /// </summary>
    public override void Stop()
    {
      IsStop = true;
    }
  }
}
