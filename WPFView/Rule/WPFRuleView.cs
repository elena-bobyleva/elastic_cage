using Model;
using Model.Menu.Elements;
using System.Windows;
using View.Menu.Elements;
using View.Rule;
using WPFView.Menu.Elements;

namespace WPFView.Rule
{
  /// <summary>
  /// Представление окна правил
  /// </summary>
  public class WPFRuleView : RuleView
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
    /// <param name="parRule">модель окна правил</param>
    public WPFRuleView(ScreenMenu parRule) : base(parRule)
    {
      Init();
    }

    /// <summary>
    /// Отображение окна правил
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
      this.AddScreen(_screen.Screen);
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
    /// Перерисовка окна правил
    /// </summary>
    protected override void Redraw()
    {
    }

    /// <summary>
    /// Инициализация окна правил
    /// </summary>
    private void Init()
    {
      int y = 30;
      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Y = y;
        elLabel.Height = SIZE_TEXT;
        elLabel.X = 70;
        y += elLabel.Height + 10;
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
