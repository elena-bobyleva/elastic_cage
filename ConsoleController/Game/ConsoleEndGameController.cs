using ConsoleView.Game;
using Controller.Game;
using Model.Enums;
using Model.Menu.Elements;
using System;
using View.Game;

namespace ConsoleController.Game
{
  /// <summary>
  /// Контроллер окна окончания игры
  /// </summary>
  public class ConsoleEndGameController : EndGameController
  {
    /// <summary>
    /// Код Unicode для буквы А
    /// </summary>
    private const int FIRST_LETTER = 1040;

    /// <summary>
    /// Код Unicode для буквы я
    /// </summary>
    private const int LAST_LETTER = 1103;

    /// <summary>
    /// Контроллер окончания игры
    /// </summary>
    private static ConsoleEndGameController _controller;

    /// <summary>
    /// Представление окончания игры
    /// </summary>
    private EndGameView _viewEndGame = null;

    /// <summary>
    /// Состояние работы контроллера
    /// </summary>
    protected bool IsStop { get; set; }

    /// <summary>
    /// Коструктор
    /// </summary>
    private ConsoleEndGameController() : base()
    {
      End = new Model.Game.EndGame();
      _viewEndGame = new ConsoleEndGameView(End);
      foreach (ButtonElement elButton in End.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера окна окончания игры
    /// </summary>
    /// <returns>контроллер окна окончания игры</returns>
    public static ConsoleEndGameController GetController()
    {
      if (_controller == null)
      {
        _controller = new ConsoleEndGameController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public override void Start()
    {
      IsStop = false;
      _viewEndGame.Draw();
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
          case ConsoleKey.Enter:
            End.SaveRecord();
            End.SelectFocusButton();
            break;
          case ConsoleKey.Backspace:
            End.RemoveSymbol();
            break;

          /*case ConsoleKey.UpArrow:
            End.FocusButtonByNumber(0);
            break;
          case ConsoleKey.DownArrow:
            End.FocusButtonByNumber(4);
            break;*/
          default:
            if ((int)keyInfo.KeyChar >= FIRST_LETTER && (int)keyInfo.Key <= LAST_LETTER)
            {
              End.AddSymbol((int)keyInfo.KeyChar);
            }

            break;
        }
      } while (!IsStop);
    }

    /// <summary>
    /// Остановка контроллера
    /// </summary>
    public override void Stop()
    {
      IsStop = true;
    }
  }
}
