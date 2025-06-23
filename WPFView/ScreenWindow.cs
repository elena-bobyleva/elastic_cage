using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFView
{
  /// <summary>
  /// Окно экрана
  /// </summary>
  public class ScreenWindow : Window
  {
    /// <summary>
    /// Ширина окна
    /// </summary>
    private const int WIDTH_WINDOW = 720;
    
    /// <summary>
    /// Высота окна
    /// </summary>
    private const int HEIGHT_WINDOW = 540;
    /// <summary>
    /// Окно
    /// </summary>
    private static ScreenWindow _windowScreen;

    /// <summary>
    /// Контейнер для сущностей
    /// </summary>
    public Canvas Screen { get; }

    /// <summary>
    /// Конструктор
    /// </summary>
    private ScreenWindow()
    {
      Width = WIDTH_WINDOW;
      Height = HEIGHT_WINDOW;
      ResizeMode = ResizeMode.NoResize;
      Screen = new Canvas();
      Screen.Width = WIDTH_WINDOW;
      Screen.Height = HEIGHT_WINDOW;
      Screen.Background = new SolidColorBrush(Colors.DarkBlue);
      AddChild(Screen);
      Show();
    }

    /// <summary>
    /// Получение окна
    /// </summary>
    /// <returns>окно</returns>
    public static ScreenWindow GetWindowScreen()
    {
      if (_windowScreen == null)
      {
        _windowScreen = new ScreenWindow();
      }
      return _windowScreen;
    }
  }
}
