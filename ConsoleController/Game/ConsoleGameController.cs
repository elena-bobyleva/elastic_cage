using ConsoleView.Game;
using Controller.Game;
using Model.Enums;
using System;
using View.Game;

namespace ConsoleController.Game
{
  /// <summary>
  /// Контроллер окна игры
  /// </summary>
  public class ConsoleGameController : GameController
  {
    /// <summary>
    /// Контроллер игры
    /// </summary>
    private static ConsoleGameController _controller;

    /// <summary>
    /// Представление окна игры
    /// </summary>
    private GameView _viewGame = null;

    /// <summary>
    /// Состояние работы контроллера
    /// </summary>
    protected bool IsStop { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    private ConsoleGameController() : base()
    {
      Game = new Model.Game.Game();
      Game.WidthScreen = Console.WindowWidth;
      Game.HeightScreen = Console.WindowHeight;
      _viewGame = new ConsoleGameView(Game);
    }

    /// <summary>
    /// Получение контроллера игры
    /// </summary>
    /// <returns>контроллер игры</returns>
    public static ConsoleGameController GetController()
    {
      if (_controller == null)
      {
        _controller = new ConsoleGameController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера игры
    /// </summary>
    public override void Start()
    {
      IsStop = false;
      Game.End += EndGame;
      Game.Initialization();
      _viewGame.Draw();
      Game.StartGame();
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
          case ConsoleKey.Spacebar:
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
          case ConsoleKey.Escape:
            ChangeCurrentController(MenuItemCodes.Menu);
            break;
        }
      } while (!IsStop);
    }

    /// <summary>
    /// Остановка контроллера игры
    /// </summary>
    public override void Stop()
    {
      Game.StopGame();
      IsStop = true;
    }

    /// <summary>
    /// Завершение игры
    /// </summary>
    private void EndGame()
    {
      Game.StopGame();
      ChangeCurrentController(MenuItemCodes.EndGame);
    }
  }
}
