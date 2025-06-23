namespace Controller.Game
{
  /// <summary>
  /// Абстрактный класс контроллера конца игры
  /// </summary>
  public abstract class EndGameController : Controller
  {

    /// <summary>
    /// Модель окна окончания игры
    /// </summary>
    public Model.Game.EndGame End { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public EndGameController() : base()
    {
    }
  }
}
