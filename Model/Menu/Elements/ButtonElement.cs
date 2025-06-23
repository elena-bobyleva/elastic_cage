using Model.Enums;

namespace Model.Menu.Elements
{
  /// <summary>
  /// Кнопка
  /// </summary>
  public class ButtonElement
  {
    /// <summary>
    /// Делегат на перерисовку
    /// </summary>
    public delegate void dRedraw();

    /// <summary>
    /// Событие на перерисовку
    /// </summary>
    public event dRedraw Redraw = null;

    /// <summary>
    /// Событие на нажатие
    /// </summary>
    public event dSelect Select = null;

    /// <summary>
    /// Делегат на нажатие
    /// </summary>
    public delegate void dSelect();

    /// <summary>
    /// Состояние кнопки
    /// </summary>
    private States _state = States.Normal;

    /// <summary>
    /// Текст кнопки
    /// </summary>
    public string Text { get; set; }

    /// <summary>
    /// Номер кнопки
    /// </summary>
    public int Number { get; private set; }

    /// <summary>
    /// Состояние кнопки
    /// </summary>
    public States State
    {
      get
      {
        return _state;
      }
      set
      {
        _state = value;
        if (_state == States.Selected)
        {
          _state = States.Focused;
          Select?.Invoke();
        }
        else
        {
          Redraw?.Invoke();
        }
      }
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parNumber">номер</param>
    /// <param name="parText">текст</param>
    public ButtonElement(int parNumber, string parText)
    {
      Number = parNumber;
      Text = parText;
      State = States.Normal;
    }
  }
}
