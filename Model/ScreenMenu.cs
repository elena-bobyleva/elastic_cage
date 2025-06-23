using Model.Enums;
using Model.Menu.Elements;
using System.Collections.Generic;
using System.Linq;

namespace Model
{
  /// <summary>
  /// Окно
  /// </summary>
  public class ScreenMenu : Screen
  {
    /// <summary>
    /// Кнопки
    /// </summary>
    private Dictionary<int, ButtonElement> _buttons = new Dictionary<int, ButtonElement>();

    /// <summary>
    /// Текстовые поля
    /// </summary>
    private List<LabelElement> _labels = new List<LabelElement>();

    /// <summary>
    /// Поля для ввода
    /// </summary>
    private List<TextBoxElement> _textBoxs = new List<TextBoxElement>();

    /// <summary>
    /// Кнопки
    /// </summary>
    public ButtonElement[] Buttons
    {
      get => _buttons.Values.ToArray();
    }

    /// <summary>
    /// Номер кнопки, находящейся в фокусе
    /// </summary>
    public int FocusNumberButton { get; set; }

    /// <summary>
    /// Текстовые поля
    /// </summary>
    public LabelElement[] Labels
    {
      get => _labels.ToArray();
    }

    /// <summary>
    /// Поля для ввода
    /// </summary>
    public TextBoxElement[] TextBoxs
    {
      get => _textBoxs.ToArray();
    }

    /// <summary>
    /// Конструктор
    /// </summary>
    public ScreenMenu()
    {
    }

    /// <summary>
    /// Фокус на следующую кнопку
    /// </summary>
    public void FocusNext()
    {
      int currentFocusNumber = FocusNumberButton;
      if (FocusNumberButton == Buttons.Length - 1)
      {
        FocusNumberButton = 0;
      }
      else
      {
        FocusNumberButton++;
      }

      Buttons[FocusNumberButton].State = States.Focused;
      Buttons[currentFocusNumber].State = States.Normal;
    }

    /// <summary>
    /// Фокус на предыдущую кнопку
    /// </summary>
    public void FocusPrevious()
    {
      int currentFocusNumber = FocusNumberButton;
      if (FocusNumberButton == 0)
      {
        FocusNumberButton = Buttons.Length - 1;
      }
      else
      {
        FocusNumberButton--;
      }

      Buttons[FocusNumberButton].State = States.Focused;
      Buttons[currentFocusNumber].State = States.Normal;
    }

    /// <summary>
    /// Фокус на кнопку по номеру
    /// </summary>
    /// <param name="parNumber">номер</param>
    public void FocusButtonByNumber(int parNumber)
    {
      int currentFocusedIndex = FocusNumberButton;
      ButtonElement menuItem = _buttons[parNumber];
      FocusNumberButton = new List<ButtonElement>(Buttons).IndexOf(menuItem);

      if (currentFocusedIndex != -1)
      {
        Buttons[currentFocusedIndex].State = States.Normal;
      }

      Buttons[FocusNumberButton].State = States.Focused;
    }

    /// <summary>
    /// Изменение состояния кнопки на выбрана
    /// </summary>
    public void SelectFocusButton()
    {
      Buttons[FocusNumberButton].State = States.Selected;
    }

    /// <summary>
    /// Добавление кнопки
    /// </summary>
    /// <param name="parButtonElement">кнопка</param>
    protected void AddButtonElement(ButtonElement parButtonElement)
    {
      _buttons.Add(parButtonElement.Number, parButtonElement);
    }

    /// <summary>
    /// Добавление текстового поля
    /// </summary>
    /// <param name="parLabelElement">текстовое поле</param>
    protected void AddLabelElement(LabelElement parLabelElement)
    {
      _labels.Add(parLabelElement);
    }

    /// <summary>
    /// Добавление поля для ввода
    /// </summary>
    /// <param name="parTextBoxElement">поле для ввода</param>
    protected void AddTextBoxElement(TextBoxElement parTextBoxElement)
    {
      _textBoxs.Add(parTextBoxElement);
    }

    /// <summary>
    /// Удаление всех текстовых полей
    /// </summary>
    protected void DeleteLabels()
    {
      _labels.Clear();
    }
  }
}
