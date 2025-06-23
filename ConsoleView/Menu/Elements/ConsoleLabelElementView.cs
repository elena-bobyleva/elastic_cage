using Model.Menu.Elements;
using View.Menu.Elements;

namespace ConsoleView.Menu.Elements
{
  /// <summary>
  /// Консольное представление текстового поля
  /// </summary>
  public class ConsoleLabelElementView : LabelElementView
  {

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parLabelElement">текстовое поле</param>
    public ConsoleLabelElementView(LabelElement parLabelElement) : base(parLabelElement)
    {
    }

    /// <summary>
    /// Отображение текстового поля
    /// </summary>
    public override void Draw()
    {
      _output.OutputString(Label.Text, X, Y);
    }
  }
}
