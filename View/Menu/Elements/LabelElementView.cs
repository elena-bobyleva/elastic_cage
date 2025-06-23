using Model.Menu.Elements;

namespace View.Menu.Elements
{
  /// <summary>
  /// Представление текстового поля
  /// </summary>
  public abstract class LabelElementView : View
  {
    /// <summary>
    /// Текстовое поле
    /// </summary>
    private LabelElement _label = null;

    /// <summary>
    /// Текстовое поле
    /// </summary>
    public LabelElement Label { get => _label; set => _label=value; }

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Ширина текстового поля
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота текстового поля
    /// </summary>
    public int Height { get; set; }


    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parLabel">текстовое поле</param>
    public LabelElementView(LabelElement parLabel)
    {
      Label = parLabel;
    }
  }
}
