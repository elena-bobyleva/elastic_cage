using Controller.Controllers;
using Controller.Game;
using Controller.Menu;
using Controller.Records;
using Controller.Rule;
using WPFController.Game;
using WPFController.Menu;
using WPFController.Records;
using WPFController.Rule;

namespace WPFController
{
  /// <summary>
  /// Класс управления контроллерами
  /// </summary>
  public class WPFControllers : Controllers
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    public WPFControllers()
    {
    }

    /// <summary>
    /// Получает контроллер окна окончания игры
    /// </summary>
    /// <returns>контроллер окна окончания игры</returns>
    protected override EndGameController GetEndGameController()
    {
      return WPFEndGameController.GetController();
    }

    /// <summary>
    /// Получает контроллер окна игры
    /// </summary>
    /// <returns>контроллер окна игры</returns>
    protected override GameController GetGameController()
    {
      return WPFGameController.GetController();
    }

    /// <summary>
    /// Получает контроллер окна правил
    /// </summary>
    /// <returns>контроллер окна правил</returns>
    protected override RuleController GetRuleController()
    {
      return WPFRuleController.GetController();
    }

    /// <summary>
    /// Получает контроллер окна главного меню
    /// </summary>
    /// <returns>контроллер окна главного меню</returns>
    protected override MainMenuController GetMenuController()
    {
      return WPFMainMenuController.GetController();
    }

    /// <summary>
    /// Получает контроллер окна рекордов
    /// </summary>
    /// <returns>контроллер окна рекордов</returns>
    protected override RecordsController GetRecordsController()
    {
      return WPFRecordsController.GetController();
    }

    
  }
}
