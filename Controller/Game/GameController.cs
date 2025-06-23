namespace Controller.Game
{
  /// <summary>
  /// Абстрактный класс контроллера игры
  /// </summary>
  public abstract class GameController : Controller
  {
    /// <summary>
    /// Модель окна игры
    /// </summary>
    public Model.Game.Game Game { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public GameController() : base()
    {
    }
  }
}
