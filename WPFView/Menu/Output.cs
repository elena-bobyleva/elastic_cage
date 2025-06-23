using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPFView.Menu
{
  /// <summary>
  /// Класс для создания представления элементов
  /// </summary>
  public class Output
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public Output()
    {
    }

    /// <summary>
    /// Создание представления кнопки
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <returns>кнопка</returns>
    public Button CreateButton(int parX, int parY)
    {
      Button button = new Button();
      button.BorderThickness = new Thickness(0);
      button.VerticalAlignment = VerticalAlignment.Bottom;
      Canvas.SetTop(button, parY);
      Canvas.SetLeft(button, parX);
      return button;
    }

    /// <summary>
    /// Создание представления текстового поля
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parText">текст</param>
    /// <param name="parSize">размер текста</param>
    /// <returns>текстовое поле</returns>
    public TextBlock CreateTextBlock(int parX, int parY, string parText, int parSize)
    {
      TextBlock textBlock = new TextBlock();
      textBlock.Text = parText;
      textBlock.FontSize = parSize;
      textBlock.Foreground = Brushes.White;
      textBlock.HorizontalAlignment = HorizontalAlignment.Stretch;
      textBlock.FontFamily = new FontFamily("Times New Roman");
      textBlock.VerticalAlignment = VerticalAlignment.Center;
      Canvas.SetTop(textBlock, parY);
      Canvas.SetLeft(textBlock, parX);
      return textBlock;
    }

    /// <summary>
    /// Создание представления поля для ввода
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parSize">размер текста</param>
    /// <param name="parHeight">высота</param>
    /// <param name="parWidth">ширина</param>
    /// <returns>поле для ввода</returns>
    public Label CreateLabel(int parX, int parY, int parSize, int parHeight, int parWidth)
    {
      Label label = new Label();
      label.Foreground = Brushes.White;
      label.Background = Brushes.DarkBlue;
      label.FontSize = parSize;
      label.FontFamily = new FontFamily("Times New Roman");
      label.HorizontalContentAlignment = HorizontalAlignment.Stretch;
      label.VerticalContentAlignment = VerticalAlignment.Center;
      label.Height = parHeight;
      label.Width = parWidth;
      Canvas.SetTop(label, parY);
      Canvas.SetLeft(label, parX);
      return label;
    }
  }
}
