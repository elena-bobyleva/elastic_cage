using ConsoleView.Menu.Elements;
using Model.Game;
using Model.Menu.Elements;
using System;
using System.Linq;
using View.Game;
using View.Menu.Elements;

namespace ConsoleView.Game
{
  /// <summary>
  /// Консольное представление окна конца игры
  /// </summary>
  public class ConsoleEndGameView : EndGameView
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
    /// <param name="parEndGameScreen">модель окна конца игры</param>
    public ConsoleEndGameView(EndGame parEndGameScreen) : base(parEndGameScreen)
    {
      Init();
    }

    /// <summary>
    /// Отображение окна конца игры
    /// </summary>
    public override void Draw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.Clear();
      Labels[1].Label.Text = "Набранные очки: " + EndGame.Score.ToString();
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Draw();
      }
      foreach (ButtonElementView elButton in Buttons)
      {
        elButton.Draw();
      }

      foreach (TextBoxElementView elTextBox in TextBoxs)
      {
        elTextBox.Draw();
      }
    }

    /// <summary>
    /// Инициализация координат объектов окна
    /// </summary>
    private void Init()
    {
      int y = 2;
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Y = y;
        elLabel.X = WIDTH / 2 - elLabel.Label.Text.Length / 2;
        y += 2;
      }

      foreach (TextBoxElementView elTextBox in TextBoxs)
      {
        elTextBox.X = WIDTH / 2 - elTextBox.Width / 2;
        elTextBox.Y = HEIGHT / 2;
      }

      Console.WindowHeight = HEIGHT;
      Console.WindowWidth = WIDTH;

      Console.CursorVisible = true; //false

      ButtonElementView[] button = Buttons;
      Height = button.Length;
      Width = button.Max(x => x.Width);

      button[0].X = Console.WindowWidth / 2;
      button[0].Y = Console.WindowHeight - Height * 4;
      /*button[1].X = Console.WindowWidth / 2;
      button[1].Y = Console.WindowHeight - Height * 4+2;*/
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
    /// Создание консольного представления поля для ввода
    /// </summary>
    /// <param name="parTextBox">поле для ввода</param>
    /// <returns>консольное представление поля для ввода</returns>
    protected override TextBoxElementView CreateTextBoxElement(TextBoxElement parTextBox)
    {
      return new ConsoleTextBoxElementView(parTextBox);
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
    /// Перерисовка окна окончания игры
    /// </summary>
    protected override void Redraw()
    {
    }
  }
}
