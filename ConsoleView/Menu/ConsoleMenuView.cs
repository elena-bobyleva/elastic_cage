using ConsoleView.Menu.Elements;
using Model;
using Model.Menu.Elements;
using System;
using System.Linq;
using View.Menu;
using View.Menu.Elements;

namespace ConsoleView.Menu
{
  /// <summary>
  /// Консольное представление окна главного меню
  /// </summary>
  public class ConsoleMenuView : MainMenuView
  {
    /// <summary>
    /// Ширина окна
    /// </summary>
    private const int WIDTH = 90;

    /// <summary>
    /// Высота окна
    /// </summary>
    private const int HEIGHT = 30;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">главное меню</param>
    public ConsoleMenuView(ScreenMenu parMenu) : base(parMenu)
    {
      Init();
    }

    /// <summary>
    /// Отображение окна главного меню
    /// </summary>
    public override void Draw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.Clear();
      _output.PrintGameTitle();
      foreach (ButtonElementView elButton in Buttons)
      {
        elButton.Draw();
      }
    }

    /// <summary>
    /// Создание консольного представления кнопки
    /// </summary>
    /// <param name="parButtonElement">кнопка</param>
    /// <returns>консольное представление кнопки</returns>
    protected override ButtonElementView CreateButtonElement(ButtonElement parButtonElement)
    {
      return new ConsoleButtonElementView(parButtonElement);
    }

    /// <summary>
    /// Создание консольного представления текстового поля
    /// </summary>
    /// <param name="parLabelElement">текстовое поле</param>
    /// <returns>консольное представление текстового поля</returns>
    protected override LabelElementView CreateLabelElement(LabelElement parLabelElement)
    {
      return new ConsoleLabelElementView(parLabelElement);
    }

    /// <summary>
    /// Перерисовывание окна главного меню
    /// </summary>
    protected override void Redraw()
    {
    }

    /// <summary>
    /// Инициализация главного меню
    /// </summary>
    private void Init()
    {
      Console.Title = "Electric Cage";
      Console.WindowHeight = HEIGHT;
      Console.WindowWidth = WIDTH;

      Console.SetBufferSize(WIDTH, HEIGHT);

      Console.CursorVisible = false;

      ButtonElementView[] menu = Buttons;
      Height = menu.Length;
      Width = menu.Max(x => x.Width);

      X = Console.WindowWidth / 3 * 2;
      Y = Console.WindowHeight / 2 - Width / 4;

      int y = Y;

      for (int i = 0; i < menu.Length; i++)
      {
        menu[i].X = X;
        menu[i].Y = y + i;
        y++;
      }
    }
  }
}
