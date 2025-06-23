using Model.Game.Entities;
using System.Collections.Generic;
using View.Game.Entities;

namespace View.Game
{
  /// <summary>
  /// Представление игры
  /// </summary>
  public abstract class GameView : View
  {
    /// <summary>
    /// Представления сущностей
    /// </summary>
    private List<EntityView> _entities = null;

    /// <summary>
    /// Представления сущностей
    /// </summary>
    protected List<EntityView> Entities => _entities;

    /// <summary>
    /// Координата х
    /// </summary>
    public int X { get; set; }

    /// <summary>
    /// Координата у
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Модель игры
    /// </summary>
    protected Model.Game.Game Screen { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parScreenGame">модель игры</param>
    public GameView(Model.Game.Game parScreenGame)
    {
      Screen = parScreenGame;
      Screen.Redraw += Redraw;
      _entities = new List<EntityView>();

      foreach (Entity elEntity in parScreenGame.Entities)
      {
        _entities.Add(CreateEntity(elEntity));
      }

    }

    /// <summary>
    /// Перерисовка окна
    /// </summary>
    protected abstract void Redraw();

    /// <summary>
    /// Создание представления сущности
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <returns>представление сущности</returns>
    protected abstract EntityView CreateEntity(Entity parEntity);

    /// <summary>
    /// Очищение представлений сущностей
    /// </summary>
    protected void ClearEntities()
    {
      _entities = new List<EntityView>();
    }
  }
}
