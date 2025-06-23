namespace Model.Menu.Elements
{
  /// <summary>
  /// Текстовое поле
  /// </summary>
  public class LabelElement
  {
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
    /// <param name="parText">текст</param>
    public LabelElement(string parText)
    {
      Text = parText;
    }
  }
}
