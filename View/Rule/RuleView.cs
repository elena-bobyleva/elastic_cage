using Model;
using Model.Menu.Elements;
using System.Collections.Generic;
using System.Linq;
using View.Menu.Elements;

namespace View.Rule
{
  /// <summary>
  /// Представление правил
  /// </summary>
  public abstract class RuleView : View
  {
    /// <summary>
    /// Правила
    /// </summary>
    private ScreenMenu _rule = null;

    /// <summary>
    /// Представления кнопок
    /// </summary>
    private Dictionary<int, ButtonElementView> _buttons = null;

    /// <summary>
    /// Представления текстовых полей
    /// </summary>
    private List<LabelElementView> _labels = null;

    /// <summary>
    /// Представления кнопок
    /// </summary>
    protected ButtonElementView[] Buttons => _buttons.Values.ToArray();

    /// <summary>
    /// Представления текстовых полей
    /// </summary>
    protected LabelElementView[] Labels => _labels.ToArray();

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Ширина
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// Высота
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parRule">правила</param>
    public RuleView(ScreenMenu parRule)
    {
      _rule = parRule;
      _buttons = new Dictionary<int, ButtonElementView>();
      _labels = new List<LabelElementView>();

      foreach (LabelElement elRule in parRule.Labels)
      {
        _labels.Add(CreateLabelElement(elRule));
      }

      foreach (ButtonElement elButton in parRule.Buttons)
      {
        _buttons.Add(elButton.Number, CreateButtonElement(elButton));
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

  }
}
