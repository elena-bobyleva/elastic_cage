using Controller.Rule;
using Model.Enums;
using Model.Menu.Elements;
using System.Windows.Input;
using View.Rule;
using WPFView;

namespace WPFController.Rule
{
  /// <summary>
  /// Контроллер окна правил
  /// </summary>
  public class WPFRuleController : RuleController
  {
    /// <summary>
    /// Сущность контроллера правил
    /// </summary>
    private static WPFRuleController _controller;

    /// <summary>
    /// Представление окна правил
    /// </summary>
    private RuleView _viewRule = null;

    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    private WPFRuleController() : base()
    {
      _screen = ScreenWindow.GetWindowScreen();
      Rule = new Model.Rule.Rule();
      _viewRule = new WPFView.Rule.WPFRuleView(Rule);
      foreach (ButtonElement elButton in Rule.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера правил
    /// </summary>
    /// <returns>контроллер правил</returns>
    public static WPFRuleController GetController()
    {
      if (_controller == null)
      {
        _controller = new WPFRuleController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера правил
    /// </summary>
    public override void Start()
    {
      _screen.KeyDown += OnKeyDownHandler;
      _viewRule.Draw();
    }

    /// <summary>
    /// Остановка контроллера правил
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
          Rule.SelectFocusButton();
          break;
      }
    }
  }
}
