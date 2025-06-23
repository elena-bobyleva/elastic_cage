using Model.Menu.Elements;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using View.Menu.Elements;

namespace WPFView.Menu.Elements
{
  /// <summary>
  /// Представление кнопки
  /// </summary>
  public class WPFButtonElementView : ButtonElementView
  {
    /// <summary>
    /// Высота кнопки
    /// </summary>
    private const int HEIGHT = 60;
    /// <summary>
    /// Ширина кнопки
    /// </summary>
    private const int WIDTH = 160;

    /// <summary>
    /// Размер шрифта
    /// </summary>
    private const int SIZE_TEXT = 16;

    /// <summary>
    /// Кнопка
    /// </summary>
    private Button _button = null;

    /// <summary>
    /// Текст
    /// </summary>
    private TextBlock _text = null;

    /// <summary>
    /// Вывод
    /// </summary>
    private Output _output = new Output();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parButtonElement">модель кнопки</param>
    public WPFButtonElementView(ButtonElement parButtonElement) : base(parButtonElement)
    {
      Height = HEIGHT;
      Width = WIDTH;
    }

    /// <summary>
    /// Инициализация кнопки
    /// </summary>
    private void Init()
    {
      _button = _output.CreateButton(X, Y);
      _text = _output.CreateTextBlock(X, Y, Button.Text, SIZE_TEXT);
      _button.Content = _text;
    }

    /// <summary>
    /// Отображение кнопки
    /// </summary>
    public override void Draw()
    {
      Init();
      ChangeColourButton();
    }

    /// <summary>
    /// Перерисовывание кнопки
    /// </summary>
    protected override void Redraw()
    {
      ChangeColourButton();
    }

    /// <summary>
    /// Изменение цвета текста в зависимости от состояния кнопки
    /// </summary>
    private void ChangeColourButton()
    {
      if (Button.State == Model.Enums.States.Normal)
      {
        _button.Background = Brushes.DarkBlue;
        _text.Foreground = Brushes.Black;
      }
      else
      {
        _button.Background = Brushes.DarkBlue;
        _text.Foreground = Brushes.White;
      }
    }

    /// <summary>
    /// Добавление кнопки на экран
    /// </summary>
    /// <param name="parScreen">окно</param>
    public void AddChildButton(FrameworkElement parScreen)
    {
      ((IAddChild)parScreen).AddChild(_button);
    }

  }
}
