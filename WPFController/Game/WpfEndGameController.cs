using Controller.Game;
using Model.Enums;
using Model.Menu.Elements;
using System.Windows.Input;
using View.Game;
using WPFView;

namespace WPFController.Game
{
  /// <summary>
  /// Контроллер окна окончания игры
  /// </summary>
  public class WPFEndGameController : EndGameController
  {
    /// <summary>
    /// Код System.Windows.Input.Key для буквы A
    /// </summary>
    private const int FIRST_LETTER = 44;
    /// <summary>
    /// Код System.Windows.Input.Key для буквы Z
    /// </summary>
    private const int LAST_LETTER = 69;

    /// <summary>
    /// Контроллер окончания игры
    /// </summary>
    private static WPFEndGameController _controller;

    /// <summary>
    /// Представление окончания игры
    /// </summary>
    private EndGameView _viewEndGame = null;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private WPFEndGameController() : base()
    {
      _screen = ScreenWindow.GetWindowScreen();
      End = new Model.Game.EndGame();
      _viewEndGame = new WPFView.Game.WPFEndGameView(End);
      foreach (ButtonElement elButton in End.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера окна окончания игры
    /// </summary>
    /// <returns>контроллер окна окончания игры</returns>
    public static WPFEndGameController GetController()
    {
      if (_controller == null)
      {
        _controller = new WPFEndGameController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public override void Start()
    {
      _viewEndGame.Draw();
      _screen.KeyDown += OnKeyDown;
    }
    /// <summary>
    /// Остановка контроллера
    /// </summary>
    public override void Stop()
    {
      _screen.KeyDown -= OnKeyDown;
    }
    /// <summary>
    /// Нажатие клавиши с клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnKeyDown(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Enter:
          End.SaveRecord();
          End.SelectFocusButton();
          break;
        case Key.Back:
          End.RemoveSymbol();
          break;
        case Key key when (int)key >= FIRST_LETTER && (int)key <= LAST_LETTER:
          End.AddSymbol((int)key + 'A' - FIRST_LETTER);
          break;
      }
    }
  }
}
