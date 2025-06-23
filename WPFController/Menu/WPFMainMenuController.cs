using Controller.Menu;
using Model.Enums;
using Model.Menu;
using Model.Menu.Elements;
using System.Windows.Input;
using View.Menu;
using WPFView;

namespace WPFController.Menu
{
  /// <summary>
  /// Контроллер главного меню
  /// </summary>
  public class WPFMainMenuController : MainMenuController
  {
    /// <summary>
    /// Контроллер главного меню
    /// </summary>
    private static WPFMainMenuController _controller;

    /// <summary>
    /// Представление окна главного меню
    /// </summary>
    private MainMenuView _viewMenu = null;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private WPFMainMenuController() : base()
    {
      Menu = new MainMenu();
      _screen = ScreenWindow.GetWindowScreen();
      _viewMenu = new WPFView.Menu.WPFMainMenuView(Menu);
      foreach (ButtonElement elButton in Menu.Buttons)
      {
        if ((MenuItemCodes)elButton.Number != MenuItemCodes.Exit)
        {
          elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
        }
        else
        {
          elButton.Select += () => { _screen.Close(); };
        }
      }

    }

    /// <summary>
    /// Получение контроллера главного меню
    /// </summary>
    /// <returns>контроллер главного меню</returns>
    public static WPFMainMenuController GetController()
    {
      if (_controller == null)
      {
        _controller = new WPFMainMenuController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера главного меню
    /// </summary>
    public override void Start()
    {
      _screen.KeyDown += OnKeyDownHandler;
      _viewMenu.Draw();
    }

    /// <summary>
    /// Остановка контроллера главного меню
    /// </summary>
    public override void Stop()
    {
      _screen.KeyDown -= OnKeyDownHandler;
    }

    /// <summary>
    /// Нажатие клавиши с клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Up:
          Menu.FocusPrevious();
          break;
        case Key.Down:
          Menu.FocusNext();
          break;
        case Key.Enter:
          Menu.SelectFocusButton();
          break;
      }
    }
  }
}
