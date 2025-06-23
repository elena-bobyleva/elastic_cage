namespace Model.Enums
{
  /// <summary>
  /// Направления движения сущностей
  /// </summary>
  public enum DirectionsType : int
  {
    /// <summary>
    /// влево вверх
    /// </summary>
    LeftUp,
    /// <summary>
    /// влево вниз
    /// </summary>
    LeftDown,
    /// <summary>
    /// вправо вниз
    /// </summary>
    RightDown,
    /// <summary>
    /// вправо вверх
    /// </summary>
    RightUp,
    /// <summary>
    /// вниз
    /// </summary>
    Down,
    /// <summary>
    /// не двигается
    /// </summary>
    Stop
  }
}
