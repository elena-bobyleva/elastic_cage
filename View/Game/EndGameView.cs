using Model.Game;
using Model.Menu.Elements;
using System.Collections.Generic;
using System.Linq;
using View.Menu.Elements;

namespace View.Game
{
  /// <summary>
  /// Представление окна окончания игры
  /// </summary>
  public abstract class EndGameView : View
  {
    /// <summary>
    /// Представления кнопок
    /// </summary>
    private Dictionary<int, ButtonElementView> _buttons = null;
    /// <summary>
    /// Представления тестовых полей
    /// </summary>
    private List<LabelElementView> _labels = null;
    /// <summary>
    /// Представления полей для ввода
    /// </summary>
    private List<TextBoxElementView> _textBoxs = null;

    /// <summary>
    /// Представления кнопок
    /// </summary>
    protected ButtonElementView[] Buttons => _buttons.Values.ToArray();
    /// <summary>
    /// Представления текстовых полей
    /// </summary>
    protected LabelElementView[] Labels => _labels.ToArray();
    /// <summary>
    /// Представления полей для ввода
    /// </summary>
    protected TextBoxElementView[] TextBoxs => _textBoxs.ToArray();

    /// <summary>
    /// Модель окна окончания игры
    /// </summary>
    protected EndGame EndGame { get; set; }

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }
    /// <summary>
    /// Ширина окна на представлении
    /// </summary>
    public int Width { get; protected set; }
    /// <summary>
    /// Высота окна на предствлении
    /// </summary>
    public int Height { get; protected set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEndGame">модель окна окончания игры</param>
    public EndGameView(EndGame parEndGame)
    {
      EndGame = parEndGame;
      _buttons = new Dictionary<int, ButtonElementView>();
      _labels = new List<LabelElementView>();
      _textBoxs = new List<TextBoxElementView>();

      foreach (LabelElement elLabel in parEndGame.Labels)
      {
        _labels.Add(CreateLabelElement(elLabel));
      }

      foreach (ButtonElement elButton in parEndGame.Buttons)
      {
        _buttons.Add(elButton.Number, CreateButtonElement(elButton));
      }

      foreach (TextBoxElement elTextBox in parEndGame.TextBoxs)
      {
        _textBoxs.Add(CreateTextBoxElement(elTextBox));
      }
    }

    /// <summary>
    /// Перерисовка окна
    /// </summary>
    protected abstract void Redraw();

    /// <summary>
    /// Создание представления кнопки
    /// </summary>
    /// <param name="parButton">кнопка</param>
    /// <returns>представление кнопки</returns>
    protected abstract ButtonElementView CreateButtonElement(ButtonElement parButton);

    /// <summary>
    /// Создание представления текстового поля
    /// </summary>
    /// <param name="parLabel">текстовое поле</param>
    /// <returns>представление текстового поля</returns>
    protected abstract LabelElementView CreateLabelElement(LabelElement parLabel);

    /// <summary>
    /// Создание представления поля для ввода
    /// </summary>
    /// <param name="parTextBox">поле для ввода</param>
    /// <returns>представление поля для ввода</returns>
    protected abstract TextBoxElementView CreateTextBoxElement(TextBoxElement parTextBox);
  }
}
