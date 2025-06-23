using Model.Game;
using Model.Menu.Elements;
using System.Windows;
using View.Game;
using View.Menu.Elements;
using WPFView.Menu.Elements;

namespace WPFView.Game
{
  /// <summary>
  /// Представление окна конца игры
  /// </summary>
  public class WPFEndGameView : EndGameView
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
    /// <param name="parEndGameScreen">модель окна окончания игры</param>
    public WPFEndGameView(EndGame parEndGameScreen) : base(parEndGameScreen)
    {
      Init();
    }

    /// <summary>
    /// Отображение окна конца игры
    /// </summary>
    public override void Draw()
    {
      Labels[1].Label.Text = "Набранные очки: " + EndGame.Score.ToString();
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

        foreach (TextBoxElementView elTextBox in TextBoxs)
        {
          elTextBox.Draw();
        }
        AddScreen(_screen.Screen);
      });
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
    /// Создание представления поля для ввода
    /// </summary>
    /// <param name="parTextBoxElement">поле для ввода</param>
    /// <returns>представление поля для ввода</returns>
    protected override TextBoxElementView CreateTextBoxElement(TextBoxElement parTextBoxElement)
    {
      return new WPFTextBoxElementView(parTextBoxElement);
    }

    /// <summary>
    /// Перерисовка окна окончания игры
    /// </summary>
    protected override void Redraw()
    {
    }

    /// <summary>
    /// Инициализация окна конца игры
    /// </summary>
    private void Init()
    {
      int y = 150;

      foreach (LabelElementView elLabel in Labels)
      {
        elLabel.Y = y;
        elLabel.Height = SIZE_TEXT;
        elLabel.X = (int)_screen.Screen.Width/2-elLabel.Label.Text.Length/2*SIZE_TEXT/2;
        y += SIZE_TEXT * 2;
      }

      foreach (TextBoxElementView elTextBox in TextBoxs)
      {
        elTextBox.X = (int)_screen.Width / 2 - elTextBox.Width / 2;
        elTextBox.Y = y+SIZE_TEXT;
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
      foreach (TextBoxElementView elTextBox in TextBoxs)
      {
        ((WPFTextBoxElementView)elTextBox).AddChildTextBox(parScreen);
      }
    }

  }
}
