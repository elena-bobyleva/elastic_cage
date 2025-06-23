using Model;
using Model.Menu.Elements;
using System.Windows;
using View.Menu;
using View.Menu.Elements;
using WPFView.Menu.Elements;

namespace WPFView.Menu
{
  /// <summary>
  /// Представление окна главного меню
  /// </summary>
  public class WPFMainMenuView : MainMenuView
  {
    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = ScreenWindow.GetWindowScreen();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parMenu">модель окна главного меню</param>
    public WPFMainMenuView(ScreenMenu parMenu) : base(parMenu)
    {
      Init();
    }

    /// <summary>
    /// Отображение главного меню
    /// </summary>
    public override void Draw()
    {
      Application.Current.Dispatcher.Invoke(() =>
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
        this.AddScreen(_screen.Screen);
      });

    }

    /// <summary>
    /// Перерисовывание окна главного меню
    /// </summary>
    protected override void Redraw()
    {
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
    /// Инициализация окна главного меню
    /// </summary>
    private void Init()
    {
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Y = (int)_screen.Height % 100 / 2;
        elLabel.Height = (int)_screen.Width / 10 - ((int)_screen.Width / 60);
        elLabel.X = (int)_screen.Width / 8;
      }

      int y = (int)_screen.Height / 3;

      foreach (ButtonElementView elButton in Buttons)
      {
        elButton.Y = y;
        elButton.X = (int)_screen.Width - elButton.Width / 2 * 3;
        y += elButton.Height/2;
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
