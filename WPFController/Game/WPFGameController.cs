using Controller.Game;
using Model.Enums;
using System.Windows.Input;
using View.Game;
using WPFView;

namespace WPFController.Game
{
  /// <summary>
  /// Контроллер окна игры
  /// </summary>
  public class WPFGameController : GameController
  {
    /// <summary>
    /// Контроллер игры
    /// </summary>
    private static WPFGameController _controller;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = null;

    /// <summary>
    /// Представление игры
    /// </summary>
    private GameView _viewGame = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private WPFGameController() : base()
    {
      _screen = ScreenWindow.GetWindowScreen();
      Game = new Model.Game.Game();
      Game.HeightScreen = _screen.Height;
      Game.WidthScreen = _screen.Width;
      _viewGame = new WPFView.Game.WPFGameView(Game);
    }

    /// <summary>
    /// Получение контроллера окна игры
    /// </summary>
    /// <returns>контроллер окна игры</returns>
    public static WPFGameController GetController()
    {
      if (_controller == null)
      {
        _controller = new WPFGameController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public override void Start()
    {
      Game.End += EndGame;
      Game.Initialization();
      _viewGame.Draw();
      _screen.KeyDown += OnKeyDownHandler;
      Game.StartGame();
    }

    /// <summary>
    /// Остановка контроллера
    /// </summary>
    public override void Stop()
    {
      _screen.KeyDown -= OnKeyDownHandler;
      Game.StopGame();
    }

    /// <summary>
    /// Завершение игры
    /// </summary>
    private void EndGame()
    {
      //Game.StopGame();
      ChangeCurrentController(MenuItemCodes.EndGame);
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
        case Key.Space:
          DirectionsType direction = Game.SpaceShip.DirectionType;
          if (direction == DirectionsType.Stop)
          {
            Game.MovementLeftUp();
          }
          if (direction == DirectionsType.LeftUp)
          {
            Game.MovementLeftDown();
          }
          if (direction == DirectionsType.LeftDown)
          {
            Game.MovementRightDown();
          }
          if (direction == DirectionsType.RightDown)
          {
            Game.MovementRightUp();
          }
          if (direction == DirectionsType.RightUp)
          {
            Game.MovementLeftUp();
          }
          break;
        case Key.Escape:
          ChangeCurrentController(MenuItemCodes.Menu);
          break;
      }
    }

  }
}
