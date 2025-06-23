using Model.Menu.Elements;

namespace View.Menu.Elements
{
  /// <summary>
  /// Представление кнопки
  /// </summary>
  public abstract class ButtonElementView : View
  {
    /// <summary>
    /// Кнопка
    /// </summary>
    private ButtonElement _button = null;

    /// <summary>
    /// Кнопка
    /// </summary>
    public ButtonElement Button { get => _button; set => _button=value; }

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Ширина кнопки
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота кнопки
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parButton">кнопка</param>
    public ButtonElementView(ButtonElement parButton)
    {
      Button = parButton;
      Button.Redraw += Redraw;
    }

    /// <summary>
    /// Перерисовка кнопки
    /// </summary>
    protected abstract void Redraw();
  }
}
