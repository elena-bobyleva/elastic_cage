using Model.Game.Entities;
using System.Windows;
using System.Windows.Shapes;
using View.Game;
using View.Game.Entities;
using WPFView.Game.Entities;

namespace WPFView.Game
{
  /// <summary>
  /// Представление окна игры
  /// </summary>
  public class WPFGameView : GameView
  {
    /// <summary>
    /// Окно
    /// </summary>
    private ScreenWindow _screen = ScreenWindow.GetWindowScreen();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameScreen">модель игры</param>
    public WPFGameView(Model.Game.Game parGameScreen) : base(parGameScreen)
    {
    }

    /// <summary>
    /// Отображение игры
    /// </summary>
    public override void Draw()
    {
      _screen.Screen.Children.Clear();
      Shape _field = GameOutput.CreateField(1, 1, 702, 500);
      _screen.Screen.Children.Add(_field);
      foreach (EntityView elEntity in Entities)
      {
        elEntity.Draw();
      }
      AddScreen(_screen.Screen);
    }

    /// <summary>
    /// Создание представления для сущности
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <returns>представление сущности</returns>
    protected override EntityView CreateEntity(Entity parEntity)
    {
      return new WPFEntityView(parEntity);
    }


    /// <summary>
    /// Перерисовывание сущностей
    /// </summary>
    protected override void Redraw()
    {
      Application.Current.Dispatcher.Invoke(() =>
      {
        _screen.Screen.Children.Clear();
        ClearEntities();
        Shape _field = GameOutput.CreateField(1, 1, 982, 510);
        _screen.Screen.Children.Add(_field);
        foreach (Entity elEntity in Screen.Entities)
        {
          Entities.Add(CreateEntity(elEntity));
        }
        foreach (EntityView elEntity in Entities)
        {
          elEntity.Draw();
        }
        AddScreen(_screen.Screen);
      });
    }

    /// <summary>
    /// Добавление сущностей на экран
    /// </summary>
    /// <param name="parScreen">экран</param>
    private void AddScreen(FrameworkElement parScreen)
    {
      foreach (EntityView elEntity in Entities)
      {
        ((WPFEntityView)elEntity).AddChildEntity(parScreen);
      }
    }
  }
}
