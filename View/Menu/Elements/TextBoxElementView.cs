using Model.Menu.Elements;

namespace View.Menu.Elements
{
  /// <summary>
  /// Представление поля для ввода
  /// </summary>
  public abstract class TextBoxElementView : View
  {
    /// <summary>
    /// Поле для ввода
    /// </summary>
    private TextBoxElement _textBox = null;

    /// <summary>
    /// Поле для ввода
    /// </summary>
    public TextBoxElement TextBox { get => _textBox; set => _textBox=value; }

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Ширина поля для ввода
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота поля для ввода
    /// </summary>
    public int Height { get; set; }


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTextBox">поле для ввода</param>
    public TextBoxElementView(TextBoxElement parTextBox)
    {
      _textBox = parTextBox;
      _textBox.Redraw += Redraw;
    }

    /// <summary>
    /// Перерисовка поля для ввода
    /// </summary>
    protected abstract void Redraw();
  }
}
