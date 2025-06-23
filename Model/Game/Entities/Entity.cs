using Model.Enums;

namespace Model.Game.Entities
{
  /// <summary>
  /// Сущность
  /// </summary>
  public abstract class Entity
  {
    /// <summary>
    /// Делегат на перерисовку сущности
    /// </summary>
    public delegate void dNeedRedraw();
    /// <summary>
    /// Событие на перерисовку сущности
    /// </summary>
    public event dNeedRedraw NeedRedraw = null;

    /// <summary>
    /// 
    /// </summary>
    private double _x;
    /// <summary>
    /// Координата у
    /// </summary>
    private double _y;
    /// <summary>
    /// Тип сущности
    /// </summary>
    private EntitiesType _entityType;
    /// <summary>
    /// Направление движения
    /// </summary>
    private DirectionsType _directionType;

    /// <summary>
    /// Координата х
    /// </summary>
    public double X { get => _x; set => _x=value; }
    /// <summary>
    /// Координата у
    /// </summary>
    public double Y { get => _y; set => _y=value; }
    /// <summary>
    /// Тип сущности
    /// </summary>
    public EntitiesType EntityType { get => _entityType; set => _entityType=value; }
    /// <summary>
    /// Направление движения
    /// </summary>
    public DirectionsType DirectionType { get => _directionType; set => _directionType=value; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parEntityType">тип сущности</param>
    /// <param name="parDirectionsType">направление движения</param>
    public Entity(double parX, double parY, EntitiesType parEntityType, DirectionsType parDirectionsType)
    {
      X=parX;
      Y=parY;
      EntityType = parEntityType;
      DirectionType = parDirectionsType;
    }

    /// <summary>
    /// Перерисовывание сущности
    /// </summary>
    public void RedrawEntity()
    {
      NeedRedraw?.Invoke();
    }
  }
}
