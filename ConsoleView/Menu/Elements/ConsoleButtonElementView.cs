using Model.Menu.Elements;
using View.Menu.Elements;

namespace ConsoleView.Menu.Elements
{
  /// <summary>
  /// Консольное представление кнопки
  /// </summary>
  public class ConsoleButtonElementView : ButtonElementView
  {
    /// <summary>
    /// Высота кнопки
    /// </summary>
    private const int HEIGHT = 3;

    /// <summary>
    /// Ширина кнопки
    /// </summary>
    private const int WIDTH = 20;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parButtonElement">кнопка</param>
    public ConsoleButtonElementView(ButtonElement parButtonElement) : base(parButtonElement)
    {
      Height = HEIGHT;
      Width = WIDTH;
    }

    /// <summary>
    /// Отображение кнопки
    /// </summary>
    public override void Draw()
    {
      _output.OutputButton(Button.Text, X - Button.Text.Length / 2, Y, Button.State);
    }

    /// <summary>
    /// Перерисовывание кнопки
    /// </summary>
    protected override void Redraw()
    {
      Draw();
    }
  }
}
