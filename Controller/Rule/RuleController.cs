using Model;

namespace Controller.Rule
{
  /// <summary>
  /// Абстрактный класс контроллера правил
  /// </summary>
  public abstract class RuleController : Controller
  {
    /// <summary>
    /// Модель окна правил
    /// </summary>
    protected ScreenMenu Rule { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public RuleController() : base()
    {
    }
  }
}
