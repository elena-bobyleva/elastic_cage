using System.Windows;

namespace ElectricCage
{
  /// <summary>
  /// Логика взаимодействия для App.xaml
  /// </summary>
  public partial class App : Application
  {
    private void Start(object sender, StartupEventArgs e)
    {
      //WPFController.WPFControllers controller = new WPFController.WPFControllers();
      new WPFController.WPFControllers().Start();
    }

  }
}
