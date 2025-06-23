using Model.Enums;
using Model.Game.Entities;
using System;

namespace ConsoleView.Game
{
  /// <summary>
  /// Вывод на консоль для игры
  /// </summary>
  public class GameOutput
  {
    /// <summary>
    /// Цвет сущностей
    /// </summary>
    private const ConsoleColor WHITE = ConsoleColor.White;

    /// <summary>
    /// Вывод
    /// </summary>
    private static GameOutput _out = null;

    /// <summary>
    /// Блокировка
    /// </summary>
    private Object _lock = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private GameOutput()
    {
      _lock = new Object();
    }

    /// <summary>
    /// Получает вывод
    /// </summary>
    /// <returns>вывод</returns>
    public static GameOutput GetOut()
    {
      if (_out == null)
      {
        _out = new GameOutput();
      }
      return _out;
    }

    /// <summary>
    /// Отображение сущностей
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    public void DrawEntityView(Entity parEntity, int parX, int parY)
    {
      switch (parEntity.EntityType)
      {
        case EntitiesType.SpaceShip:
          PrintGameField();
          //PrintSpaceShip(parX, parY, parEntity.DirectionType);
          //ClearSpaceShip(parX, parY, parEntity.DirectionType);
          break;
        case EntitiesType.ElectricBall:
          //PrintElectricBall(parX, parY);
          //ClearElectricBall(parX, parY);
          break;
      }
    }

    /// <summary>
    /// Перерисовывание сущностей
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <param name="parOldX">предыдущая координата х</param>
    /// <param name="parOldY">предыдущая координата у</param>
    /// <param name="parNewX">новая координата х</param>
    /// <param name="parNewY">новая координата у</param>
    public void Redraw(Entity parEntity, int parOldX, int parOldY, int parNewX, int parNewY)
    {
      switch (parEntity.EntityType)
      {
        case EntitiesType.SpaceShip:
          ClearSpaceShip(parOldX, parOldY, parEntity.DirectionType);
          PrintSpaceShip(parNewX, parNewY, parEntity.DirectionType);
          break;
        case EntitiesType.ElectricBall:
          ClearElectricBall(parOldX, parOldY);
          PrintElectricBall(parNewX, parNewY);
          break;
      }
    }

    /// <summary>
    /// Вывод на консоль космического корабля
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parDirectionType">направление движения</param>
    private void PrintSpaceShip(int parX, int parY, DirectionsType parDirectionType)
    {
      lock (_lock)
      {
        if (parY < 30)
        {
          Console.ForegroundColor = WHITE;
          Console.SetCursorPosition(parX, parY);
          switch (parDirectionType)
          {
            case DirectionsType.LeftUp:
              Console.Write("▄");
              Console.SetCursorPosition(parX+1, parY);
              Console.Write("▄");
              Console.SetCursorPosition(parX, parY+1);
              Console.Write("▀");
              break;
            case DirectionsType.LeftDown:
              Console.Write("▀");
              Console.SetCursorPosition(parX+1, parY);
              Console.Write("▀");
              Console.SetCursorPosition(parX, parY-1);
              Console.Write("▄");
              break;
            case DirectionsType.RightDown:
              Console.Write("▀");
              Console.SetCursorPosition(parX-1, parY);
              Console.Write("▀");
              Console.SetCursorPosition(parX, parY-1);
              Console.Write("▄");
              break;
            case DirectionsType.RightUp:
              Console.Write("▄");
              Console.SetCursorPosition(parX-1, parY);
              Console.Write("▄");
              Console.SetCursorPosition(parX, parY+1);
              Console.Write("▀");
              break;

          }
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
    }

    /// <summary>
    /// Вывод на консоль границ
    /// </summary>
    public void PrintGameField()
    {
      lock (_lock)
      {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.White;

        for (int i = 1; i<88; i++)
        {
          Console.SetCursorPosition(i, 0);
          Console.Write("━");
          Console.SetCursorPosition(i, 29);
          Console.Write("━");
        }
        for (int i = 1; i<29; i++)
        {
          Console.SetCursorPosition(0, i);
          Console.Write("┃");
          Console.SetCursorPosition(88, i);
          Console.Write("┃");
        }
        Console.SetCursorPosition(0, 0);
        Console.Write("┏");
        Console.SetCursorPosition(88, 0);
        Console.Write("┓");
        Console.SetCursorPosition(0, 29);
        Console.Write("┗");
        Console.SetCursorPosition(88, 29);
        Console.Write("┛");
        Console.ForegroundColor = ConsoleColor.White;
      }
    }

    /// <summary>
    /// Вывод на консоль электрического шара
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    private void PrintElectricBall(int parX, int parY)
    {
      lock (_lock)
      {
        if (parX >0 && parY > 0 && parY <30)
        {
          Console.ForegroundColor = WHITE;
          Console.SetCursorPosition(parX-2, parY);
          Console.Write("*");
          Console.SetCursorPosition(parX-1, parY-1);
          Console.Write("*");
          Console.SetCursorPosition(parX-1, parY);
          Console.Write("*");
          Console.SetCursorPosition(parX-1, parY+1);
          Console.Write("*");
          Console.SetCursorPosition(parX, parY-1);
          Console.Write("*");
          Console.SetCursorPosition(parX, parY);
          Console.Write("*");
          Console.SetCursorPosition(parX, parY+1);
          Console.Write("*");
          Console.SetCursorPosition(parX+1, parY-1);
          Console.Write("*");
          Console.SetCursorPosition(parX+1, parY);
          Console.Write("*");
          Console.SetCursorPosition(parX+1, parY+1);
          Console.Write("*");
          Console.SetCursorPosition(parX+2, parY);
          Console.Write("*");
          Console.ForegroundColor = ConsoleColor.White;
        }
      }
    }

    /// <summary>
    /// Удаление с консоли космического корабля
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parDirectionType">направление движения</param>
    private void ClearSpaceShip(int parX, int parY, DirectionsType parDirectionType)
    {
      lock (_lock)
      {
        if (parX >= 0 && parY >= 0 && parY < 30)
        {
          Console.SetCursorPosition(parX, parY);
          Console.BackgroundColor = ConsoleColor.DarkBlue;
          Console.Write(" ");
          switch (parDirectionType)
          {
            case DirectionsType.LeftUp:
              Console.SetCursorPosition(parX+1, parY);
              Console.Write(" ");
              Console.SetCursorPosition(parX, parY+1);
              Console.Write(" ");
              break;
            case DirectionsType.LeftDown:
              Console.SetCursorPosition(parX+1, parY);
              Console.Write(" ");
              Console.SetCursorPosition(parX, parY-1);
              Console.Write(" ");
              break;
            case DirectionsType.RightDown:
              Console.SetCursorPosition(parX-1, parY);
              Console.Write(" ");
              Console.SetCursorPosition(parX, parY-1);
              Console.Write(" ");
              break;
            case DirectionsType.RightUp:
              Console.SetCursorPosition(parX-1, parY);
              Console.Write(" ");
              Console.SetCursorPosition(parX, parY+1);
              Console.Write(" ");
              break;

          }
        }
      }
    }

    /// <summary>
    /// Удаление с консоли электрического шара
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    public void ClearElectricBall(int parX, int parY)
    {
      lock (_lock)
      {
        if (parX >= 2 && parY >= 1)
        {
          Console.BackgroundColor = ConsoleColor.DarkBlue;
          Console.SetCursorPosition(parX-2, parY);
          Console.Write(" ");
          Console.SetCursorPosition(parX-1, parY-1);
          Console.Write(" ");
          Console.SetCursorPosition(parX-1, parY);
          Console.Write(" ");
          Console.SetCursorPosition(parX-1, parY+1);
          Console.Write(" ");
          Console.SetCursorPosition(parX, parY-1);
          Console.Write(" ");
          Console.SetCursorPosition(parX, parY);
          Console.Write(" ");
          Console.SetCursorPosition(parX, parY+1);
          Console.Write(" ");
          Console.SetCursorPosition(parX+1, parY-1);
          Console.Write(" ");
          Console.SetCursorPosition(parX+1, parY);
          Console.Write(" ");
          Console.SetCursorPosition(parX+1, parY+1);
          Console.Write(" ");
          Console.SetCursorPosition(parX+2, parY);
          Console.Write(" ");
        }
      }
    }
  }
}
