using Controller.Records;
using Model.Enums;
using Model.Menu.Elements;
using System;
using View.Records;

namespace ConsoleController.Records
{
  /// <summary>
  /// Контроллер окна рекордов
  /// </summary>
  public class ConsoleRecordsController : RecordsController
  {
    /// <summary>
    /// Контроллер окна рекордов
    /// </summary>
    private static ConsoleRecordsController _controller;

    /// <summary>
    /// Представление окна рекордов
    /// </summary>
    private RecordsView _viewRecords = null;

    /// <summary>
    /// Состояние работы контроллера
    /// </summary>
    protected bool IsStop { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    private ConsoleRecordsController() : base()
    {
      Records = new Model.Records.Records();
      _viewRecords = new ConsoleView.Records.ConsoleRecordsView(Records);
      foreach (ButtonElement elButton in Records.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера окна рекордов
    /// </summary>
    /// <returns>контроллер окна рекордов</returns>
    public static ConsoleRecordsController GetController()
    {
      if (_controller == null)
      {
        _controller = new ConsoleRecordsController();
      }

      return _controller;
    }

    /// <summary>
    /// Запуск контроллера окна рекордов
    /// </summary>
    public override void Start()
    {
      ((Model.Records.Records)Records).GetRecords();
      _viewRecords = new ConsoleView.Records.ConsoleRecordsView(Records);
      _viewRecords.Draw();

      IsStop = false;
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
          case ConsoleKey.Enter:
          case ConsoleKey.Escape:
            Records.SelectFocusButton();
            break;
        }
      } while (!IsStop);

    }

    /// <summary>
    /// Остановка контроллера окна рекордов
    /// </summary>
    public override void Stop()
    {
      IsStop = true;
    }
  }
}
