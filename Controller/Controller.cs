using Model.Enums;

namespace Controller
{
  /// <summary>
  /// Абстрактный класс контроллера
  /// </summary>
  public abstract class Controller
  {
    /// <summary>
    /// Делегат на изменение текущего контроллера
    /// </summary>
    /// <param name="parItemCode">следующий пункт меню</param>
    public delegate void dChangeController(MenuItemCodes parItemCode);
    
    /// <summary>
    /// Событие на изменение текущего контроллера
    /// </summary>
    public event dChangeController ChangeController = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    public Controller()
    {
    }

    /// <summary>
    /// Изменение текущего контроллера
    /// </summary>
    /// <param name="parItemCode">следующий пункт меню</param>
    public void ChangeCurrentController(MenuItemCodes parItemCode)
    {
      ChangeController?.Invoke(parItemCode);
    }

    /// <summary>
    /// Запуск контроллера
    /// </summary>
    public abstract void Start();

    /// <summary>
    /// Остановка контроллера
    /// </summary>
    public abstract void Stop();
  }
}
