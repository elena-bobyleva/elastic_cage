namespace Model.Menu.Elements
{
  /// <summary>
  /// Поле для ввода
  /// </summary>
  public class TextBoxElement
  {
    /// <summary>
    /// Делегат на перерисовку поля для ввода
    /// </summary>
    public delegate void dRedraw();
    /// <summary>
    /// Событие на перерисовку поля для ввода
    /// </summary>
    public event dRedraw Redraw = null;

    /// <summary>
    /// Текст
    /// </summary>
    private string _text;
    /// <summary>
    /// Текст
    /// </summary>
    public string Text { get => _text; set => _text=value; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public TextBoxElement()
    {
      Text = "";
    }

    /// <summary>
    /// Изменение текста
    /// </summary>
    /// <param name="parText">текст</param>
    public void ChangeText(string parText)
    {
      Text = parText;
      Redraw?.Invoke();
    }
  }
}
