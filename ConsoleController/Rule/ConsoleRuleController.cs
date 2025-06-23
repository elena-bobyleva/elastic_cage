using Controller.Rule;
using Model.Enums;
using Model.Menu.Elements;
using System;
using View.Rule;

namespace ConsoleController.Rule
{
  /// <summary>
  /// Контроллер окна правил
  /// </summary>
  public class ConsoleRuleController : RuleController
  {
    /// <summary>
    /// Сущность консольного контроллера правил
    /// </summary>
    private static ConsoleRuleController _controller;

    /// <summary>
    /// Представление окна правил
    /// </summary>
    private RuleView _viewRule = null;

    /// <summary>
    /// Состояние работы контроллера
    /// </summary>
    protected bool IsStop { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    private ConsoleRuleController() : base()
    {
      Rule = new Model.Rule.Rule();
      _viewRule = new ConsoleView.Rule.ConsoleRuleView(Rule);
      foreach (ButtonElement elButton in Rule.Buttons)
      {
        elButton.Select += () => { ChangeCurrentController((MenuItemCodes)elButton.Number); };
      }
    }

    /// <summary>
    /// Получение контроллера правил
    /// </summary>
    /// <returns>контроллер правил</returns>
    public static ConsoleRuleController GetController()
    {
      if (_controller == null)
      {
        _controller = new ConsoleRuleController();
      }
      return _controller;
    }

    /// <summary>
    /// Запуск контроллера правил
    /// </summary>
    public override void Start()
    {
      _viewRule.Draw();
      IsStop = false;
      do
      {
        ConsoleKeyInfo keyInfo = Console.ReadKey();
        switch (keyInfo.Key)
        {
          case ConsoleKey.Enter:
          case ConsoleKey.Escape:
            Rule.SelectFocusButton();
            break;
        }
      } while (!IsStop);

    }

    /// <summary>
    /// Остановка контроллера правил
    /// </summary>
    public override void Stop()
    {
      IsStop = true;
    }
  }
}
