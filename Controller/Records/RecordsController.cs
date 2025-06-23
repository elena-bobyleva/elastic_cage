using Model;

namespace Controller.Records
{
  /// <summary>
  /// Абстрактный класс контроллера рекордов
  /// </summary>
  public abstract class RecordsController : Controller
  {
    /// <summary>
    /// Модель окна рекордов
    /// </summary>
    protected ScreenMenu Records { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public RecordsController() : base()
    {
    }
  }
}
