using Model.Game.Entities;

namespace View.Game.Entities
{
  /// <summary>
  /// Представление сущности
  /// </summary>
  public abstract class EntityView : View
  {
    /// <summary>
    /// Сущность
    /// </summary>
    private Entity _entity = null;

    /// <summary>
    /// Сущность
    /// </summary>
    public Entity Entity
    {
      get
      {
        return _entity;
      }
    }

    /// <summary>
    /// Координата х
    /// </summary>
    public double X { get; set; }
    /// <summary>
    /// Координата у
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parEntity">сущность</param>
    public EntityView(Entity parEntity)
    {
      _entity = parEntity;
      _entity.NeedRedraw += RedrawEntity;
    }

    /// <summary>
    /// Перерисовка сущности
    /// </summary>
    protected abstract void RedrawEntity();
  }
}
