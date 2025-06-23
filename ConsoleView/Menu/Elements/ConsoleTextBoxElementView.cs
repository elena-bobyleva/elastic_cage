using Model.Menu.Elements;
using System;
using System.Text;
using View.Menu.Elements;

namespace ConsoleView.Menu.Elements
{
  /// <summary>
  /// Консольное представление поля для ввода
  /// </summary>
  public class ConsoleTextBoxElementView : TextBoxElementView
  {
    /// <summary>
    /// Ширина поля для ввода
    /// </summary>
    private const int WIDTH = 20;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Коструктор
    /// </summary>
    /// <param name="parTextBox">поле для ввода</param>
    public ConsoleTextBoxElementView(TextBoxElement parTextBox) : base(parTextBox)
    {
      Width = WIDTH;
    }

    /// <summary>
    /// Отображение поля для ввода
    /// </summary>
    public override void Draw()
    {
      Console.SetCursorPosition(X, Y);
    }

    /// <summary>
    /// Перерисовывания поля для ввода
    /// </summary>
    protected override void Redraw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      _output.OutputString(new StringBuilder().Insert(0, " ", WIDTH).ToString(), X, Y);
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      _output.OutputString(TextBox.Text, X, Y);
    }
  }
}
