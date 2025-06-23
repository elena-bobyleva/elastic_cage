using Controller.Records;
using Model.Enums;
using Model.Menu.Elements;
using System.Windows.Input;
using View.Records;
using WPFView;

namespace WPFController.Records
{
  /// <summary>
  /// Контроллер окна рекордов
  /// </summary>
  public class WPFRecordsController : RecordsController
  {
    /// <summary>
    /// Контроллер окна рекордов
    /// </summary>
    private static WPFRecordsController _controller;

    /// <summary>
    /// Представление окна рекордов
    /// </summary>
    private RecordsView _viewRecords = null;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private WPFRecordsController() : base()
    {
      Records = new Model.Records.Records();
      _screen = ScreenWindow.GetWindowScreen();
      _viewRecords = new WPFView.Records.WPFRecordsView(Records);
      foreach (ButtonElement elButton in Records.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера окна рекордов
    /// </summary>
    /// <returns>контроллер окна рекордов</returns>
    public static WPFRecordsController GetController()
    {
      if (_controller == null)
      {
        _controller = new WPFRecordsController();
      }

      return _controller;
    }

    /// <summary>
    /// Запуск контроллера окна рекордов
    /// </summary>
    public override void Start()
    {
      ((Model.Records.Records)Records).GetRecords();
      _viewRecords = new WPFView.Records.WPFRecordsView(Records);
      _screen.KeyDown += OnKeyDownHandler;
      _viewRecords.Draw();
    }

    /// <summary>
    /// Остановка контроллера окна рекордов
    /// </summary>
    public override void Stop()
    {
      _screen.KeyDown -= OnKeyDownHandler;
    }

    /// <summary>
    /// Нажатие клавиши с клавиатуры
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public void OnKeyDownHandler(object sender, KeyEventArgs e)
    {
      switch (e.Key)
      {
        case Key.Enter:
        case Key.Escape:
          Records.SelectFocusButton();
          break;
      }
    }
  }
}
