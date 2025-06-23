using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Enums;
using Model.Game;
using Model.Game.Entities;

namespace UnitTest
{
  /// <summary>
  /// Класс с модульными тестами
  /// </summary>
  [TestClass]
  public class Test
  {
    /// <summary>
    /// Тестирование инициализации игры
    /// изначально космический корабль должен находиться на координате (60;20), направление движения LeftUp, 
    /// координата х электрических шаров отлична от 0, координата у равна 2,
    /// счет равен 0
    /// </summary>
    [TestMethod]
    public void TestInitialization()
    {
      Game game = new Game();
      Assert.AreEqual(60, game.SpaceShip.X);
      Assert.AreEqual(20, game.SpaceShip.Y);
      Assert.AreEqual(DirectionsType.LeftUp, game.SpaceShip.DirectionType);
      Assert.AreNotEqual(0, game.ElectricBallFirst.X);
      Assert.AreEqual(2, game.ElectricBallFirst.Y);
      Assert.AreNotEqual(0, game.ElectricBallSecond.X);
      Assert.AreEqual(2, game.ElectricBallSecond.Y);
      Assert.AreNotEqual(0, game.ElectricBallThird.X);
      Assert.AreEqual(2, game.ElectricBallThird.Y);
      Assert.AreNotEqual(0, game.ElectricBallFourth.X);
      Assert.AreEqual(2, game.ElectricBallFourth.Y);
      Assert.AreEqual(0, game.Score);
    }

    /// <summary>
    /// Тестирование изменения направления движения космического корабля
    /// Изменение с LeftUp на LeftDown
    /// </summary>
    [TestMethod]
    public void TestChangeDirectionShipLeftDown()
    {
      Game game = new Game();
      game.MovementLeftDown();
      Assert.AreEqual(DirectionsType.LeftDown, game.SpaceShip.DirectionType);
    }

    /// <summary>
    /// Тестирование изменения направления движения космического корабля
    /// Изменение с LeftUp на RightDown
    /// </summary>
    [TestMethod]
    public void TestChangeDirectionShipRightDown()
    {
      Game game = new Game();
      game.MovementRightDown();
      Assert.AreEqual(DirectionsType.RightDown, game.SpaceShip.DirectionType);
    }

    /// <summary>
    /// Тестирование изменения направления движения космического корабля
    /// Изменение с LeftUp на RightUp
    /// </summary>
    [TestMethod]
    public void TestChangeDirectionShipRightUp()
    {
      Game game = new Game();
      game.MovementRightUp();
      Assert.AreEqual(DirectionsType.RightUp, game.SpaceShip.DirectionType);
    }

    /// <summary>
    /// Тестирование изменения направления движения космического корабля
    /// Изменение с LeftDown на LeftUp
    [TestMethod]
    public void TestChangeDirectionShipLeftUp()
    {
      Game game = new Game();
      game.SpaceShip.DirectionType = DirectionsType.LeftDown;
      game.MovementLeftUp();
      Assert.AreEqual(DirectionsType.LeftUp, game.SpaceShip.DirectionType);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат космического корабля при движении влево вверх
    /// </summary>
    [TestMethod]
    public void TestMovementShipLeftUp()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      int speedShip = game.SpeedSpaceShip;
      game.SpaceShip.Movement(speedShip*game.MoveTime, game.HeightScreen, game.WidthScreen);
      double x = game.SpaceShip.X;
      double y = game.SpaceShip.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      game.MovementEntities();
      Assert.AreEqual(x, game.SpaceShip.X);
      Assert.AreEqual(y, game.SpaceShip.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат космического корабля при движении влево вниз
    /// </summary>
    [TestMethod]
    public void TestMovementShipLeftDown()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      int speedShip = game.SpeedSpaceShip;
      game.SpaceShip.DirectionType = DirectionsType.LeftDown;
      game.SpaceShip.Movement(speedShip*game.MoveTime, game.HeightScreen, game.WidthScreen);
      double x = game.SpaceShip.X;
      double y = game.SpaceShip.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      game.MovementLeftDown();
      game.MovementEntities();
      Assert.AreEqual(x, game.SpaceShip.X);
      Assert.AreEqual(y, game.SpaceShip.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат космического корабля при движении вправо вниз
    /// </summary>
    [TestMethod]
    public void TestMovementShipRightDown()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      int speedShip = game.SpeedSpaceShip;
      game.SpaceShip.DirectionType = DirectionsType.RightDown;
      game.SpaceShip.Movement(speedShip*game.MoveTime, game.HeightScreen, game.WidthScreen);
      double x = game.SpaceShip.X;
      double y = game.SpaceShip.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      game.MovementRightDown();
      game.MovementEntities();
      Assert.AreEqual(x, game.SpaceShip.X);
      Assert.AreEqual(y, game.SpaceShip.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат космического корабля при движении вправо вверх
    /// </summary>
    [TestMethod]
    public void TestMovementShipRightUp()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      int speedShip = game.SpeedSpaceShip;
      game.SpaceShip.DirectionType = DirectionsType.RightUp;
      game.SpaceShip.Movement(speedShip*game.MoveTime, game.HeightScreen, game.WidthScreen);
      double x = game.SpaceShip.X;
      double y = game.SpaceShip.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 10;
      game.MovementRightUp();
      game.MovementEntities();
      Assert.AreEqual(x, game.SpaceShip.X);
      Assert.AreEqual(y, game.SpaceShip.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат первого электрического шара
    /// </summary>
    [TestMethod]
    public void TestMovementElectricBallFirst()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      int speedBall = game.SpeedElectricBallFirst;
      game.ElectricBallFirst.Movement(speedBall*game.MoveTime, game.HeightScreen);
      double y = game.ElectricBallFirst.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      game.MovementEntities();
      Assert.AreEqual(y, game.ElectricBallFirst.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат второго электрического шара
    /// </summary>
    [TestMethod]
    public void TestMovementElectricBallSecond()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      int speedBall = game.SpeedElectricBallSecond;
      game.ElectricBallSecond.Movement(speedBall*game.MoveTime, game.HeightScreen);
      double y = game.ElectricBallSecond.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      game.MovementEntities();
      Assert.AreEqual(y, game.ElectricBallSecond.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат третьего электрического шара
    /// </summary>
    [TestMethod]
    public void TestMovementElectricBallThird()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      int speedBall = game.SpeedElectricBallThird;
      game.ElectricBallThird.Movement(speedBall*game.MoveTime, game.HeightScreen);
      double y = game.ElectricBallThird.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      game.MovementEntities();
      Assert.AreEqual(y, game.ElectricBallThird.Y);
    }

    /// <summary>
    /// Тестирование движения сущностей
    /// сравнение координат четвертого электрического шара
    /// </summary>
    [TestMethod]
    public void TestMovementElectricBallFourth()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      int speedBall = game.SpeedElectricBallFourth;
      game.ElectricBallFourth.Movement(speedBall*game.MoveTime, game.HeightScreen);
      double y = game.ElectricBallFourth.Y;

      game.Initialization();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      game.MoveTime = 2;
      game.MovementEntities();
      Assert.AreEqual(y, game.ElectricBallFourth.Y);
    }

    /// <summary>
    /// Тестирование изменения координат электрического шара
    /// координата х должна быть отлична от 0, координата у  равна 2
    /// количество сущностей увеличено на 1
    /// </summary>
    [TestMethod]
    public void TestCreateNewBall()
    {
      Game game = new Game();
      int countEntity = game.Entities.Length;
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      ElectricBall electricBall = new ElectricBall(0, 0, EntitiesType.ElectricBall, DirectionsType.Down);
      game.CreateNewBall(electricBall, 10, 80);
      Assert.AreEqual(2, electricBall.Y);
      Assert.AreNotEqual(0, electricBall.X);
      Assert.AreEqual(countEntity+1, game.Entities.Length);
    }

    /// <summary>
    /// Тестирование проверки положения электрического шара
    /// если координата у больше 28 возвращает true, иначе - false
    /// </summary>
    [TestMethod]
    public void TestCheckBallLocation()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      ElectricBall electricBall = new ElectricBall(10, 20, EntitiesType.ElectricBall, DirectionsType.Down);
      Assert.AreEqual(false, game.CheckBallLocation(electricBall));
      electricBall.Y = game.HeightScreen;
      Assert.AreEqual(true, game.CheckBallLocation(electricBall));
    }

    /// <summary>
    /// Тестирование проверки на столкновения между электрическим шаром и космическим кораблем
    /// если столкновение произошло, то состояние игрового процесса IsStop принимает значение true
    /// в противном случае - false
    /// </summary>
    [TestMethod]
    public void TestCheckBallCollision()
    {
      Game game = new Game();
      game.SpaceShip.X = 10;
      game.SpaceShip.Y = 10;
      game.ElectricBallFirst.X = 10;
      game.ElectricBallFirst.Y = 30;
      game.CheckBallCollision();
      Assert.AreEqual(false, game.IsStop);
      game.SpaceShip.X = 10;
      game.SpaceShip.Y = 10;
      game.ElectricBallFirst.X = 10;
      game.ElectricBallFirst.Y = 10;
      game.CheckBallCollision();
      Assert.AreEqual(true, game.IsStop);
    }

    /// <summary>
    /// Тестирование метода перерисовки всех сущностей
    /// после выполнения количество сущностей, которых нужно перерисовать, равно 0
    /// </summary>
    [TestMethod]
    public void TestRedrawEntities()
    {
      Game game = new Game();
      game.RedrawEntities();
      Assert.AreEqual(0, game.EntitiesRedraw.Count);
    }

    /// <summary>
    /// Тестирование столкновения космического корабля с границами поля (клеткой)
    /// если координаты космического корабля выходят за границы, то состояние игрового процесса 
    /// IsStop принимает значение true, в противном случае - false
    /// </summary>
    [TestMethod]
    public void TestCheckFieldCollision()
    {
      Game game = new Game();
      game.SpaceShip.X = 10;
      game.SpaceShip.Y = 10;
      game.CheckFieldCollision();
      Assert.AreEqual(false, game.IsStop);
      game.SpaceShip.X = 0;
      game.SpaceShip.Y = 10;
      game.CheckFieldCollision();
      Assert.AreEqual(true, game.IsStop);
    }

    /// <summary>
    /// Тестирование проверки пересечения координат электрического шара и трех пар координат космического корабля
    /// (метод CheckCoordinate() является вспомогательным для метода CheckBallCollision())
    /// если координаты пересекаются возвращается true, иначе - false
    /// </summary>
    [TestMethod]
    public void TestCheckCoordinate()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      ElectricBall electricBall = new ElectricBall(30, 20, EntitiesType.ElectricBall, DirectionsType.Down);
      Assert.AreEqual(false, game.CheckCollisionElectricBallCoordinateShip(electricBall, 30, 11, 31, 11, 30, 12));
      electricBall.Y = 12;
      Assert.AreEqual(true, game.CheckCollisionElectricBallCoordinateShip(electricBall, 30, 11, 31, 11, 30, 12));
    }

    /// <summary>
    /// Тестирование проверки пересечения координат электрического шара и одной из пар координат космического корабля
    /// (метод CheckCoordinateBallShip() является вспомогательным для метода CheckCoordinate())
    /// если координаты пересекаются возвращается true, иначе - false
    /// </summary>
    [TestMethod]
    public void TestCheckCoordinateBallShip()
    {
      Game game = new Game();
      game.WidthScreen = 90;
      game.HeightScreen = 30;
      ElectricBall electricBall = new ElectricBall(30, 20, EntitiesType.ElectricBall, DirectionsType.Down);
      Assert.AreEqual(false, game.CheckCoordinateBallShip(electricBall, 30, 11));
      electricBall.Y = 12;
      Assert.AreEqual(true, game.CheckCoordinateBallShip(electricBall, 30, 11));
    }
  }
}
