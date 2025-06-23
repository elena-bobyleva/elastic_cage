using Model.Menu.Elements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using View.Menu.Elements;

namespace WPFView.Menu.Elements
{
  /// <summary>
  /// Представление текстового поля
  /// </summary>
  public class WPFLabelElementView : LabelElementView
  {
    /// <summary>
    /// Текстовое поле
    /// </summary>
    private TextBlock _text;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parLabelElement">модель текстового поля</param>
    public WPFLabelElementView(LabelElement parLabelElement) : base(parLabelElement)
    {

    }

    /// <summary>
    /// Отображение текстового поля
    /// </summary>
    public override void Draw()
    {
      _text = _output.CreateTextBlock(X, Y, Label.Text, Height);
    }

    /// <summary>
    /// Добавление текстового поля на экран
    /// </summary>
    /// <param name="parScreen">окно</param>
    public void AddChildLabel(FrameworkElement parScreen)
    {
      ((IAddChild)parScreen).AddChild(_text);
    }
  }
}
