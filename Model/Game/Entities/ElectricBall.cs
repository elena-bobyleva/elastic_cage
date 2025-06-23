using Model.Enums;

namespace Model.Game.Entities
{
  /// <summary>
  /// Электрический шар
  /// </summary>
  public class ElectricBall : Entity
  {
    /// <summary>
    /// Номер шара
    /// </summary>
    private int _numberBall = 0;
    /// <summary>
    /// Номер шара
    /// </summary>
    public int NumberBall { get => _numberBall; set => _numberBall=value; }

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parEntityType">тип сущности</param>
    /// <param name="parDirectionType">направление движения</param>
    public ElectricBall(double parX, double parY, EntitiesType parEntityType, DirectionsType parDirectionType) : base(parX, parY, parEntityType, parDirectionType)
    {
      X = parX;
      Y = parY;
      EntityType = parEntityType;
      DirectionType = parDirectionType;
    }
    /// <summary>
    /// Увеличение номера шара
    /// </summary>
    public void CreateNewBall()
    {
      NumberBall++;
    }
    /// <summary>
    /// Передвижение шара
    /// </summary>
    /// <param name="parSpeed">скорость</param>
    /// <param name="parHeightScreen">высота экрана</param>
    public void Movement(double parSpeed, double parHeightScreen)
    {
      if (DirectionType == DirectionsType.Down)
      {
        Y += parSpeed;
      }

      if (Y >= parHeightScreen)
      {
        Y = parHeightScreen;
      }
    }
  }
}
