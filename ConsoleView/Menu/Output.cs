using Model.Enums;
using System;
using System.Collections.Generic;

namespace ConsoleView.Menu
{
  /// <summary>
  /// Вывод на консоль
  /// </summary>
  public class Output
  {
    /// <summary>
    /// Высота кнопки
    /// </summary>
    private const int BUTTON_HEIGHT = 1;

    /// <summary>
    /// Ширина кнопки
    /// </summary>
    private const int BUTTON_WIDTH = 17;

    /// <summary>
    /// Заголовок
    /// </summary>
    private string[] TITLE = new string[] { "█▀▀ █   █▀▀ ▄▀▀▄ ▀█▀ █▀▀▄ █ ▄▀▀▄   ▄▀▀▄   ▄█ ▄▀▀▄ █▀▀",
                                            "█▬▬ █   █▬▬ █     █  █▄▄▀ █ █      █    ▄▀ █ █ ▄▄ █▬▬",
                                            "█▄▄ █▄▄ █▄▄ ▀▄▄▀  █  █ ▀▄ █ ▀▄▄▀   ▀▄▄▀ █▀▀█ ▀▄▄▀ █▄▄" };

    /// <summary>
    /// Цвет шрифта (для пунктов меню)
    /// </summary>
    protected static Dictionary<States, ConsoleColor> FontColor { get; private set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Output()
    {
      FontColor = new Dictionary<States, ConsoleColor>();
      FontColor[States.Focused] = ConsoleColor.White;
      FontColor[States.Normal] = ConsoleColor.Black;
      FontColor[States.Selected] = ConsoleColor.White;
    }

    /// <summary>
    /// Вывод кнопки
    /// </summary>
    /// <param name="parText">текст кнопки</param>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parState">состояние</param>
    public void OutputButton(string parText, int parX, int parY, States parState)
    {
      Console.ForegroundColor = FontColor[parState];

      int buttonCursorXPosition = parX - (BUTTON_WIDTH / 2 - parText.Length / 2);
      int buttonCursorYPosition = parY - 1;

      Console.CursorLeft = buttonCursorXPosition;
      Console.CursorTop = buttonCursorYPosition;

      Console.SetCursorPosition(parX, parY);
      Console.Write(parText);
    }

    /// <summary>
    /// Вывод заголовка
    /// </summary>
    public void PrintGameTitle()
    {
      Console.ForegroundColor = ConsoleColor.White;
      for (int i = 0; i < TITLE.Length; i++)
      {
        Console.CursorLeft = 5;
        Console.CursorTop = 2 + i;
        Console.Write(TITLE[i]);
      }

    }

    /// <summary>
    /// Вывод строки
    /// </summary>
    /// <param name="parString">строка</param>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    public void OutputString(string parString, int parX, int parY)
    {
      Console.SetCursorPosition(parX, parY);
      Console.ForegroundColor = ConsoleColor.White;
      Console.Write(parString);
    }
  }
}
