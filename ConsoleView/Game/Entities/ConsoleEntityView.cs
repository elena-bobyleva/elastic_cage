using Model.Game.Entities;
using System;
using System.Text;
using View.Game.Entities;

namespace ConsoleView.Game.Entities
{
  /// <summary>
  /// Консольное представление сущностей
  /// </summary>
  public class ConsoleEntityView : EntityView
  {
    /// <summary>
    /// Вывод
    /// </summary>
    private GameOutput _output = GameOutput.GetOut();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEntity">сущность</param>
    public ConsoleEntityView(Entity parEntity) : base(parEntity)
    {
    }

    /// <summary>
    /// Отображение сущности
    /// </summary>
    public override void Draw()
    {
      Console.OutputEncoding = Encoding.Unicode;
      _output.DrawEntityView(Entity, (int)Entity.X, (int)Entity.Y);
    }

    /// <summary>
    /// Перерисовывание сущности
    /// </summary>
    protected override void RedrawEntity()
    {
      Console.OutputEncoding = Encoding.Unicode;
      int newX = (int)Entity.X;
      int newY = (int)Entity.Y;

      if ((newX != X || newY != Y) && newX >= 0 && newY >= 0)
      {
        _output.Redraw(Entity, (int)X, (int)Y, newX, newY);
        X = newX;
        Y = newY;
      }
    }
  }
}
