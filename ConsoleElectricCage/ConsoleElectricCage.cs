namespace ConsoleElectricCage
{
  /// <summary>
  /// Консольное приложение
  /// </summary>
  public class ConsoleElectricCage
  {
    static void Main(string[] args)
    {
      ConsoleController.ConsoleControllers console = new ConsoleController.ConsoleControllers();
      console.Start();
    }
  }
}
