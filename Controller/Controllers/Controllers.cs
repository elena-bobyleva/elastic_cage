using Controller.Game;
using Controller.Menu;
using Controller.Records;
using Controller.Rule;
using Model.Enums;

namespace Controller.Controllers
{
  /// <summary>
  /// Класс для управления контроллерами
  /// </summary>
  public abstract class Controllers
  {
    /// <summary>
    /// Текущий контроллер
    /// </summary>
    protected Controller CurrentController { get; set; }

    /// <summary>
    /// Контроллер окна главного меню
    /// </summary>
    protected MainMenuController Menu { get; set; }

    /// <summary>
    /// Контроллер окна игры
    /// </summary>
    protected GameController Game { get; set; }

    /// <summary>
    /// Контроллер окна рекордов
    /// </summary>
    protected RecordsController Records { get; set; }

    /// <summary>
    /// Контроллер окна правил
    /// </summary>
    protected RuleController Rule { get; set; }

    /// <summary>
    /// Контроллер окна конца игры
    /// </summary>
    protected EndGameController EndGame { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Controllers()
    {
    }

    /// <summary>
    /// Изменение текущего контроллера
    /// </summary>
    /// <param name="parMenuItemCode">пункт меню</param>
    public void ChangeAndStartController(MenuItemCodes parMenuItemCode)
    {
      CurrentController.Stop();
      switch (parMenuItemCode)
      {
        case MenuItemCodes.NewGame:
          CurrentController = Game;
          Game.Start();
          break;
        case MenuItemCodes.EndGame:
          CurrentController = EndGame;
          EndGame.End.Score = Game.Game.Score;
          EndGame.Start();
          break;
        case MenuItemCodes.Records:
          CurrentController = Records;
          Records.Start();
          break;
        case MenuItemCodes.Rule:
          CurrentController = Rule;
          Rule.Start();
          break;
        case MenuItemCodes.Menu:
          CurrentController = Menu;
          Menu.Start();
          break;
      }
    }

    /// <summary>
    /// Запуск работы контроллеров
    /// </summary>
    public void Start()
    {
      Menu = GetMenuController();
      Menu.ChangeController += ChangeAndStartController;
      CurrentController = Menu;

      Game = GetGameController();
      Game.ChangeController += ChangeAndStartController;

      EndGame = GetEndGameController();
      EndGame.ChangeController += ChangeAndStartController;

      Records = GetRecordsController();
      Records.ChangeController += ChangeAndStartController;

      Rule = GetRuleController();
      Rule.ChangeController += ChangeAndStartController;

      CurrentController.Start();
    }

    /// <summary>
    /// Получение контроллера главного меню
    /// </summary>
    /// <returns>контроллер главного меню</returns>
    protected abstract MainMenuController GetMenuController();

    /// <summary>
    /// Получение контроллера правил
    /// </summary>
    /// <returns>контроллер правил</returns>
    protected abstract RuleController GetRuleController();

    /// <summary>
    /// Получение контроллера рекордов
    /// </summary>
    /// <returns>контроллер рекордов</returns>
    protected abstract RecordsController GetRecordsController();

    /// <summary>
    /// Получение контроллера игры
    /// </summary>
    /// <returns>контроллер игры</returns>
    protected abstract GameController GetGameController();

    /// <summary>
    /// Получение контроллера конца игры
    /// </summary>
    /// <returns>контроллер окна окончания игры</returns>
    protected abstract EndGameController GetEndGameController();
  }
}
