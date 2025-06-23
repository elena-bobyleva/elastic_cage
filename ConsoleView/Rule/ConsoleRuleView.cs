using ConsoleView.Menu.Elements;
using Model;
using Model.Menu.Elements;
using System;
using System.Linq;
using View.Menu.Elements;
using View.Rule;

namespace ConsoleView.Rule
{
  /// <summary>
  /// Представление правил
  /// </summary>
  public class ConsoleRuleView : RuleView
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
    /// Конструктор
    /// </summary>
    /// <param name="parRule">правила</param>
    public ConsoleRuleView(ScreenMenu parRule) : base(parRule)
    {
      Init();
    }

    /// <summary>
    /// Отображение правил
    /// </summary>
    public override void Draw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.Clear();
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Draw();
      }
      Buttons[0].Draw();
    }

    /// <summary>
    /// Создание представления кнопки
    /// </summary>
    /// <param name="parButtonElement">кнопка</param>
    /// <returns>представление кнопки</returns>
    protected override ButtonElementView CreateButtonElement(ButtonElement parButtonElement)
    {
      return new ConsoleButtonElementView(parButtonElement);
    }

    /// <summary>
    /// Создание представления текстового поля
    /// </summary>
    /// <param name="parLabelElement">текстовое поле</param>
    /// <returns>представление текстового поля</returns>
    protected override LabelElementView CreateLabelElement(LabelElement parLabelElement)
    {
      return new ConsoleLabelElementView(parLabelElement);
    }

    /// <summary>
    /// Перерисовывание окна правил
    /// </summary>
    protected override void Redraw()
    {
    }

    /// <summary>
    /// Инициализация окна правил
    /// </summary>
    private void Init()
    {
      Console.WindowHeight = HEIGHT;
      Console.WindowWidth = WIDTH;

      Console.CursorVisible = false;

      X = 3;
      Y = 4;
      int y = Y;
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.X = X;
        elLabel.Y = y;
        y += Console.CursorTop + 1;
      }

      ButtonElementView[] button = Buttons;
      Height = button.Length;
      Width = button.Max(x => x.Width);

      button[0].X = Console.WindowWidth / 2;
      button[0].Y = Console.WindowHeight - Height * 4;

    }
  }
}
