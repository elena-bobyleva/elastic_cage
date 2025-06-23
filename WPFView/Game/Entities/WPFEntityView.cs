using Model.Enums;
using Model.Game.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Shapes;
using View.Game.Entities;

namespace WPFView.Game.Entities
{
  /// <summary>
  /// WPF представление сущностей
  /// </summary>
  public class WPFEntityView : EntityView
  {
    /// <summary>
    /// Фигура (форма сущности)
    /// </summary>
    private Shape _shape = null;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEntity">сущность</param>
    public WPFEntityView(Entity parEntity) : base(parEntity)
    {
    }

    /// <summary>
    /// Отображение сущности
    /// </summary>
    public override void Draw()
    {
      Entity.X = Entity.X*8;
      Entity.Y = Entity.Y*18;
      _shape = GameOutput.CreateViewEntity(Entity);
    }

    /// <summary>
    /// Перерисовка сущности
    /// </summary>
    protected override void RedrawEntity()
    {
      X = Entity.X*8;
      Y = Entity.Y*18;

      Application.Current.Dispatcher.Invoke(() =>
      {
        Canvas.SetLeft(_shape, X - _shape.Width / 2);
        Canvas.SetTop(_shape, Y - _shape.Height / 2);
        if (Entity.EntityType.Equals(EntitiesType.SpaceShip))
        {
          Canvas.SetLeft(_shape, X);
          Canvas.SetTop(_shape, Y);
          switch (Entity.DirectionType)
          {
            case DirectionsType.LeftUp:
              //_shape.Fill = new SolidColorBrush(Colors.Red);
              _shape.RenderTransform = new RotateTransform(0);
              break;
              case DirectionsType.LeftDown:
              _shape.RenderTransform = new RotateTransform(270);
              break;
            case DirectionsType.RightDown:
              _shape.RenderTransform = new RotateTransform(180);
              break;
            case DirectionsType.RightUp:
              _shape.RenderTransform = new RotateTransform(90);
              break;
          }
        }
        else
        {
          Canvas.SetLeft(_shape, X - _shape.Width / 2);
          Canvas.SetTop(_shape, Y - _shape.Height / 2);
        }

      });
    }

    /// <summary>
    /// Добавление сущности в окно
    /// </summary>
    /// <param name="parScreen"></param>
    public void AddChildEntity(FrameworkElement parScreen)
    {
      ((IAddChild)parScreen).AddChild(_shape);
    }
  }
}
