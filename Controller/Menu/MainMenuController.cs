using Model;

namespace Controller.Menu
{
  /// <summary>
  /// Абстрактный класс контроллера главного меню
  /// </summary>
  public abstract class MainMenuController : Controller
  {
    /// <summary>
    /// Модель окна главного меню
    /// </summary>
    protected ScreenMenu Menu { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public MainMenuController() : base()
    {
    }
  }
}
