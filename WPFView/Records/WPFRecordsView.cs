using Model;
using Model.Menu.Elements;
using System.Windows;
using View.Menu.Elements;
using View.Records;
using WPFView.Menu.Elements;

namespace WPFView.Records
{
  /// <summary>
  /// Представление окна рекордов
  /// </summary>
  public class WPFRecordsView : RecordsView
  {
    /// <summary>
    /// Размер шрифта
    /// </summary>
    public const int SIZE_TEXT = 16;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = ScreenWindow.GetWindowScreen();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRecords">модель окна рекордов</param>
    public WPFRecordsView(ScreenMenu parRecords) : base(parRecords)
    {
      Init();
    }

    /// <summary>
    /// Отображение окна рекордов
    /// </summary>
    public override void Draw()
    {
      _screen.Screen.Children.Clear();
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Draw();
      }
      foreach (ButtonElementView elButton in Buttons)
      {
        elButton.Draw();
      }
      AddScreen(_screen.Screen);
    }

    /// <summary>
    /// Создание представления кнопки
    /// </summary>
    /// <param name="parButtonElement">кнопка</param>
    /// <returns>представление кнопки</returns>
    protected override ButtonElementView CreateButtonElement(ButtonElement parButtonElement)
    {
      return new WPFButtonElementView(parButtonElement);
    }

    /// <summary>
    /// Создание представления текстового поля
    /// </summary>
    /// <param name="parLabelElement">текстовое поле</param>
    /// <returns>представление текстового поля</returns>
    protected override LabelElementView CreateLabelElement(LabelElement parLabelElement)
    {
      return new WPFLabelElementView(parLabelElement);
    }

    /// <summary>
    /// Перерисовка окна рекордов
    /// </summary>
    protected override void Redraw()
    {
    }

    /// <summary>
    /// Инициализация окна рекордов 
    /// </summary>
    private void Init()
    {
      int y = (int)_screen.Height/4;
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Y = y;
        elLabel.Height = SIZE_TEXT;
        elLabel.X = (int)_screen.Width / 3;
        y += SIZE_TEXT*2;
      }

      foreach (ButtonElementView elButton in Buttons)
      {
        elButton.Y = (int)_screen.Height - 110;
        elButton.X = (int)_screen.Width / 3*2;
      }
    }

    /// <summary>
    /// Добавление элементов на экран
    /// </summary>
    /// <param name="parScreen">экран</param>
    private void AddScreen(FrameworkElement parScreen)
    {
      foreach (LabelElementView elLabel in Labels)
      {
        ((WPFLabelElementView)elLabel).AddChildLabel(parScreen);
      }
      foreach (ButtonElementView elButton in Buttons)
      {
        ((WPFButtonElementView)elButton).AddChildButton(parScreen);
      }
    }
  }
}
