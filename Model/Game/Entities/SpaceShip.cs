using Model.Enums;

namespace Model.Game.Entities
{
  /// <summary>
  /// Космический корабль
  /// </summary>
  public class SpaceShip : Entity
  {
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parEntityType">тип сущности</param>
    /// <param name="parDirectionType">направление движения</param>
    public SpaceShip(double parX, double parY, EntitiesType parEntityType, DirectionsType parDirectionType) : base(parX, parY, parEntityType, parDirectionType)
    {
      X = parX;
      Y = parY;
      EntityType = parEntityType;
      DirectionType = parDirectionType;
    }
    /// <summary>
    /// Передвижение
    /// </summary>
    /// <param name="parSpeed">скорость</param>
    /// <param name="parHeightScreen">высота экрана</param>
    /// <param name="parWeightScreen">ширина экрана</param>
    public void Movement(double parSpeed, double parHeightScreen, double parWeightScreen)
    {
      if (Y <= 0)
      {
        Y = 0;
      }
      if (X <= 0)
      {
        X = 0;
      }
      if (X >= parWeightScreen)
      {
        X = parWeightScreen;
      }
      if (Y >= parHeightScreen)
      {
        Y = parHeightScreen;
      }
      switch (DirectionType)
      {
        case DirectionsType.LeftUp:
          X -= parSpeed;
          Y -= parSpeed;
          break;
        case DirectionsType.LeftDown:
          X -= parSpeed;
          Y += parSpeed;
          break;
        case DirectionsType.RightDown:
          X += parSpeed;
          Y += parSpeed;
          break;
        case DirectionsType.RightUp:
          X += parSpeed;
          Y -= parSpeed;
          break;
        case DirectionsType.Stop:
          break;
      }
    }
  }
}
