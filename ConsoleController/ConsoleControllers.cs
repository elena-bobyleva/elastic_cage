using ConsoleController.Menu;
using Controller.Menu;
using Controller.Game;
using ConsoleController.Game;
using Controller.Controllers;
using Controller.Rule;
using Controller.Records;
using ConsoleController.Rule;
using ConsoleController.Records;

namespace ConsoleController
{
  /// <summary>
  /// Класс управления контроллерами
  /// </summary>
  public class ConsoleControllers : Controllers
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public ConsoleControllers()
    {
    }

    /// <summary>
    /// Получает консольный контроллер окна окончания игры
    /// </summary>
    /// <returns>консольный контроллер окна окончания игры</returns>
    protected override EndGameController GetEndGameController()
    {
      return ConsoleEndGameController.GetController();
    }

    /// <summary>
    /// Получает консольный контроллер окна игры
    /// </summary>
    /// <returns>консольный контроллер окна игры</returns>
    protected override GameController GetGameController()
    {
      return ConsoleGameController.GetController();
    }

    /// <summary>
    /// Получает консольный контроллер окна правил
    /// </summary>
    /// <returns>консольный контроллер окна правил</returns>
    protected override RuleController GetRuleController()
    {
      return ConsoleRuleController.GetController();
    }

    /// <summary>
    /// Получает консольный контроллер окна главного меню
    /// </summary>
    /// <returns>консольный контроллер окна главного меню</returns>
    protected override MainMenuController GetMenuController()
    {
      return ConsoleMainMenuController.GetController();
    }

    /// <summary>
    /// Получает консольный контроллер окна рекордов
    /// </summary>
    /// <returns>консольный контроллер окна рекордов</returns>
    protected override RecordsController GetRecordsController()
    {
      return ConsoleRecordsController.GetController();
    }
  }
}
