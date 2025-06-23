using Model.Menu.Elements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using View.Menu.Elements;

namespace WPFView.Menu.Elements
{
  /// <summary>
  /// Представление поля для ввода
  /// </summary>
  public class WPFTextBoxElementView : TextBoxElementView
  {
    /// <summary>
    /// Ширина поля для ввода
    /// </summary>
    public const int WIDTH = 200;
    
    /// <summary>
    /// Высота поля для ввода
    /// </summary>
    public const int HEIGHT = 60;

    /// <summary>
    /// Размер шрифта
    /// </summary>
    public const int SIZE_TEXT = 16;

    /// <summary>
    /// Поле для ввода
    /// </summary>
    private Label _label = null;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parTextBox">модель поля для ввода</param>
    public WPFTextBoxElementView(TextBoxElement parTextBox) : base(parTextBox)
    {
      Height = HEIGHT;
      Width = WIDTH;
    }

    /// <summary>
    /// Отображение поля для ввода
    /// </summary>
    public override void Draw()
    {
      Init();
    }

    /// <summary>
    /// Добавление поля для ввода на экран
    /// </summary>
    /// <param name="parScreen">окно</param>
    public void AddChildTextBox(FrameworkElement parScreen)
    {
      ((IAddChild)parScreen).AddChild(_label);
    }

    /// <summary>
    /// Перерисовывание поля для ввода
    /// </summary>
    protected override void Redraw()
    {
      _label.Content = TextBox.Text;
    }

    /// <summary>
    /// Инициализация поля для ввода
    /// </summary>
    private void Init()
    {
      _label = _output.CreateLabel(X, Y, SIZE_TEXT, Height, Width);
    }
  }
}
