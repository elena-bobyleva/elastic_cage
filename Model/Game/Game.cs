using Model.Game.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace Model.Game
{
  /// <summary>
  /// Окно игры
  /// </summary>
  public class Game : Screen
  {
    /// <summary>
    /// Делегат на перерисовку сущности
    /// </summary>
    public delegate void dRedraw();
    /// <summary>
    /// Событие на перерисовку сущности
    /// </summary>
    public event dRedraw Redraw = null;
    /// <summary>
    /// Делегат на окончание игры
    /// </summary>
    public delegate void dEnd();
    /// <summary>
    /// Событие на окончание игры
    /// </summary>
    public event dEnd End = null;

    /// <summary>
    /// Космический корабль
    /// </summary>
    private SpaceShip _spaceShip = new SpaceShip(0, 0, Enums.EntitiesType.SpaceShip, Enums.DirectionsType.LeftUp);
    /// <summary>
    /// Скорость космического корабля
    /// </summary>
    private int _speedSpaceShip = 4;
    /// <summary>
    /// Первый электрический шар
    /// </summary>
    private ElectricBall _electricBallFirst = new ElectricBall(0, 0, Enums.EntitiesType.ElectricBall, Enums.DirectionsType.Down);
    /// <summary>
    /// Скорость первого электрического шара
    /// </summary>
    private int _speedElectricBallFirst = 3;
    /// <summary>
    /// Второй электрический шар
    /// </summary>
    private ElectricBall _electricBallSecond = new ElectricBall(0, 0, Enums.EntitiesType.ElectricBall, Enums.DirectionsType.Down);
    /// <summary>
    /// Скорость второго электрического шара
    /// </summary>
    private int _speedElectricBallSecond = 4;
    /// <summary>
    /// Третий электрический шар
    /// </summary>
    private ElectricBall _electricBallThird = new ElectricBall(0, 0, Enums.EntitiesType.ElectricBall, Enums.DirectionsType.Down);
    /// <summary>
    /// Скорость третьего электрического шара
    /// </summary>
    private int _speedElectricBallThird = 2;
    /// <summary>
    /// Четвертый электрический шар
    /// </summary>
    private ElectricBall _electricBallFourth = new ElectricBall(0, 0, Enums.EntitiesType.ElectricBall, Enums.DirectionsType.Down);
    /// <summary>
    /// Скорость четвертого электрического шара
    /// </summary>
    private int _speedElectricBallFourth = 3;

    /// <summary>
    /// Состояние игрового цикла
    /// </summary>
    private bool _isStop = false;
    /// <summary>
    /// Время для передвижение сущностей
    /// </summary>
    private double _moveTime = 0;
    /// <summary>
    /// Счет
    /// </summary>
    public int Score { get; set; }

    /// <summary>
    /// Электрические шары (чтобы понять конечный счет)
    /// </summary>
    private List<ElectricBall> _electricBalls = new List<ElectricBall>();
    /// <summary>
    /// Сущности, которые нужно прерисовать
    /// </summary>
    private List<Entity> _entitiesRedraw = new List<Entity>();
    /// <summary>
    /// Все сущности
    /// </summary>
    private List<Entity> _entities = new List<Entity>();

    /// <summary>
    /// Высота экрана
    /// </summary>
    public double HeightScreen { get; set; }
    /// <summary>
    /// Ширина экрана
    /// </summary>
    public double WidthScreen { get; set; }

    /// <summary>
    /// Сущности
    /// </summary>
    public Entity[] Entities { get => _entities.ToArray(); }
    /// <summary>
    /// Сущности, которые нужно прерисовать
    /// </summary>
    public List<Entity> EntitiesRedraw { get => _entitiesRedraw.ToList(); }

    /// <summary>
    /// Космический корабль
    /// </summary>
    public SpaceShip SpaceShip { get => _spaceShip; set => _spaceShip=value; }
    /// <summary>
    /// Первый электрический шар
    /// </summary>
    public ElectricBall ElectricBallFirst { get => _electricBallFirst; set => _electricBallFirst=value; }
    /// <summary>
    /// Второй электрический шар
    /// </summary>
    public ElectricBall ElectricBallSecond { get => _electricBallSecond; set => _electricBallSecond=value; }
    /// <summary>
    /// Третий электрический шар
    /// </summary>
    public ElectricBall ElectricBallThird { get => _electricBallThird; set => _electricBallThird=value; }
    /// <summary>
    /// Четвертый электрический шар
    /// </summary>
    public ElectricBall ElectricBallFourth { get => _electricBallFourth; set => _electricBallFourth=value; }
    /// <summary>
    /// Скорость первого электрического шара
    /// </summary>
    public int SpeedElectricBallFirst { get => _speedElectricBallFirst; set => _speedElectricBallFirst=value; }
    /// <summary>
    /// Скорость второго электрического шара
    /// </summary>
    public int SpeedElectricBallSecond { get => _speedElectricBallSecond; set => _speedElectricBallSecond=value; }
    /// <summary>
    /// Скорость третьего электрического шара
    /// </summary>
    public int SpeedElectricBallThird { get => _speedElectricBallThird; set => _speedElectricBallThird=value; }
    /// <summary>
    /// Скорость четвертого электрического шара
    /// </summary>
    public int SpeedElectricBallFourth { get => _speedElectricBallFourth; set => _speedElectricBallFourth=value; }
    /// <summary>
    /// Скорость космического корабля
    /// </summary>
    public int SpeedSpaceShip { get => _speedSpaceShip; set => _speedSpaceShip=value; }
    /// <summary>
    /// Врямя для передвижения сущностей
    /// </summary>
    public double MoveTime { get => _moveTime; set => _moveTime=value; }
    /// <summary>
    /// Состояние игрового цикла
    /// </summary>
    public bool IsStop { get => _isStop; set => _isStop=value; }

    /// <summary>
    /// Конструктор
    /// </summary>
    public Game() : base()
    {
      Initialization();
    }

    /// <summary>
    /// Инициализация сущностей
    /// </summary>
    public void Initialization()
    {
      _entities.Clear();
      _electricBalls.Clear();
      _entitiesRedraw.Clear();

      _spaceShip.X = 60;
      _spaceShip.Y = 20;
      _spaceShip.DirectionType = Enums.DirectionsType.LeftUp;
      lock (_entitiesRedraw)
      {
        _entitiesRedraw.Add(_spaceShip);
      }
      _entities.Add(_spaceShip);

      CreateNewBall(ElectricBallFirst, 3, 23);
      CreateNewBall(ElectricBallSecond, 24, 44);
      CreateNewBall(ElectricBallThird, 45, 65);
      CreateNewBall(ElectricBallFourth, 66, 85);
    }

    /// <summary>
    /// Старт игрового цикла
    /// </summary>
    public void StartGame()
    {
      IsStop = false;
      Initialization();
      new Thread(() =>
      {
        Stopwatch timer = new Stopwatch();
        timer.Start();
        while (!IsStop)
        {
          double start = timer.ElapsedMilliseconds;
          MovementEntities();
          double end = timer.ElapsedMilliseconds;
          MoveTime = (end - start)/1000;
        }
        timer.Stop();
      }).Start();
    }

    /// <summary>
    /// Остановка игрового цикла
    /// </summary>
    public void StopGame()
    {
      IsStop = true;
    }

    /// <summary>
    /// Перемещение сущностей
    /// </summary>
    public void MovementEntities()
    {
      SpaceShip.Movement(SpeedSpaceShip * MoveTime, HeightScreen, WidthScreen);
      _entitiesRedraw.Add(SpaceShip);

      ElectricBallFirst.Movement(SpeedElectricBallFirst *MoveTime, HeightScreen);

      if (CheckBallLocation(ElectricBallFirst))
      {
        CreateNewBall(ElectricBallFirst, 3, 23);
      }
      else
      {
        _entitiesRedraw.Add(ElectricBallFirst);
      }

      ElectricBallSecond.Movement(SpeedElectricBallSecond*MoveTime, HeightScreen);

      if (CheckBallLocation(ElectricBallSecond))
      {
        CreateNewBall(ElectricBallSecond, 24, 44);
      }
      else
      {
        _entitiesRedraw.Add(ElectricBallSecond);
      }

      ElectricBallThird.Movement(SpeedElectricBallThird*MoveTime, HeightScreen);

      if (CheckBallLocation(ElectricBallThird))
      {
        CreateNewBall(ElectricBallThird, 45, 65);
      }
      else
      {
        _entitiesRedraw.Add(ElectricBallThird);
      }

      ElectricBallFourth.Movement(SpeedElectricBallFourth*MoveTime, HeightScreen);

      if (CheckBallLocation(ElectricBallFourth))
      {
        CreateNewBall(ElectricBallFourth, 66, 85);
      }
      else
      {
        _entitiesRedraw.Add(ElectricBallFourth);
      }

      CheckFieldCollision();
      CheckBallCollision();
      RedrawEntities();
    }

    /// <summary>
    /// Изменение положения электрического шара
    /// </summary>
    /// <param name="parElectricBall">электрический шар</param>
    /// <param name="parMin">минимальная координата х</param>
    /// <param name="parMax">максимальная координата х</param>
    public void CreateNewBall(ElectricBall parElectricBall, int parMin, int parMax)
    {
      Random random = new Random();
      double x = random.Next(parMin, parMax);
      parElectricBall.X = x;
      parElectricBall.Y = 2;
      parElectricBall.CreateNewBall();
      lock (_entitiesRedraw)
      {
        _entitiesRedraw.Add(parElectricBall);
      }
      _electricBalls.Add(parElectricBall);
      _entities.Add(parElectricBall);

    }

    /// <summary>
    /// Проверка положения электрического шара
    /// </summary>
    /// <param name="parElectricBall">электрический шар</param>
    /// <returns></returns>
    public bool CheckBallLocation(ElectricBall parElectricBall)
    {
      if (parElectricBall.Y >= 28)
      {
        return true;
      }
      return false;
    }
    /// <summary>
    /// Проверка столкновения космического корабля с электрическими шарами
    /// </summary>
    public void CheckBallCollision()
    {
      int x1 = (int)Math.Round(SpaceShip.X, MidpointRounding.AwayFromZero);
      int y1 = (int)Math.Round(SpaceShip.Y, MidpointRounding.AwayFromZero);
      int x2 = 0;
      int y2 = 0;
      int x3 = 0;
      int y3 = 0;
      switch (SpaceShip.DirectionType)
      {
        case Enums.DirectionsType.LeftUp:
          x2 = (int)Math.Round(SpaceShip.X+1, MidpointRounding.AwayFromZero);
          y2 = (int)Math.Round(SpaceShip.Y, MidpointRounding.AwayFromZero);
          x3 = (int)Math.Round(SpaceShip.X, MidpointRounding.AwayFromZero);
          y3 = (int)Math.Round(SpaceShip.Y+1, MidpointRounding.AwayFromZero);
          break;
        case Enums.DirectionsType.LeftDown:
          x2 = (int)Math.Round(SpaceShip.X+1, MidpointRounding.AwayFromZero);
          y2 = (int)Math.Round(SpaceShip.Y, MidpointRounding.AwayFromZero);
          x3 = (int)Math.Round(SpaceShip.X, MidpointRounding.AwayFromZero);
          y3 = (int)Math.Round(SpaceShip.Y-1, MidpointRounding.AwayFromZero);
          break;
        case Enums.DirectionsType.RightDown:
          x2 = (int)Math.Round(SpaceShip.X-1, MidpointRounding.AwayFromZero);
          y2 = (int)Math.Round(SpaceShip.Y, MidpointRounding.AwayFromZero);
          x3 = (int)Math.Round(SpaceShip.X, MidpointRounding.AwayFromZero);
          y3 = (int)Math.Round(SpaceShip.Y-1, MidpointRounding.AwayFromZero);
          break;
        case Enums.DirectionsType.RightUp:
          x2 = (int)Math.Round(SpaceShip.X-1, MidpointRounding.AwayFromZero);
          y2 = (int)Math.Round(SpaceShip.Y, MidpointRounding.AwayFromZero);
          x3 = (int)Math.Round(SpaceShip.X, MidpointRounding.AwayFromZero);
          y3 = (int)Math.Round(SpaceShip.Y+1, MidpointRounding.AwayFromZero);
          break;
      }
      if (CheckCollisionElectricBallCoordinateShip(_electricBallFirst, x1, y1, x2, y2, x3, y3))
      {
        Score = _electricBalls.Count()-4;
        StopGame();
        End?.Invoke();
      }
      if (CheckCollisionElectricBallCoordinateShip(_electricBallSecond, x1, y1, x2, y2, x3, y3))
      {
        Score = _electricBalls.Count()-4;
        StopGame();
        End?.Invoke();
      }
      if (CheckCollisionElectricBallCoordinateShip(_electricBallThird, x1, y1, x2, y2, x3, y3))
      {
        Score = _electricBalls.Count()-4;
        StopGame();
        End?.Invoke();
      }
      if (CheckCollisionElectricBallCoordinateShip(_electricBallFourth, x1, y1, x2, y2, x3, y3))
      {
        Score = _electricBalls.Count()-4;
        StopGame();
        End?.Invoke();
      }
    }

    /// <summary>
    /// Перерисовка сущностей
    /// </summary>
    public void RedrawEntities()
    {
      foreach (Entity elEntity in _entitiesRedraw)
      {
        elEntity.RedrawEntity();
      }
      _entitiesRedraw.Clear();
    }

    /// <summary>
    /// Проверка столкновения с границами поля
    /// </summary>
    public void CheckFieldCollision()
    {
      if (SpaceShip.X<=0 || SpaceShip.Y<=0 || SpaceShip.X >= 88 || SpaceShip.Y >= 29)
      {
        Score = _electricBalls.Count()-4;
        StopGame();
        End?.Invoke();
      }
    }

    /// <summary>
    /// Проверка координат электрического шара и космического корабля
    /// </summary>
    /// <param name="parElectricBall">электрический шар</param>
    /// <param name="parX1">первая координата х</param>
    /// <param name="parY1">первая координата у</param>
    /// <param name="parX2">вторая координата х</param>
    /// <param name="parY2">вторая координата у</param>
    /// <param name="parX3">третья координата х</param>
    /// <param name="parY3">третья координата у</param>
    /// <returns>было ли столкновение</returns>
    public bool CheckCollisionElectricBallCoordinateShip(ElectricBall parElectricBall,
      int parX1, int parY1, int parX2, int parY2, int parX3, int parY3)
    {
      if (CheckCoordinateBallShip(parElectricBall, parX1, parY1))
      {
        return true;
      }
      if (CheckCoordinateBallShip(parElectricBall, parX2, parY2))
      {
        return true;
      }
      if (CheckCoordinateBallShip(parElectricBall, parX3, parY3))
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Проверка координат электрического шара и координаты космического корабля
    /// </summary>
    /// <param name="parElectricBall">электрический шар</param>
    /// <param name="parX">координата х космического корабля</param>
    /// <param name="parY">координата у космического корабля</param>
    /// <returns>было ли столкновение</returns>
    public bool CheckCoordinateBallShip(ElectricBall parElectricBall, int parX, int parY)
    {
      int x = (int)Math.Round(parElectricBall.X, MidpointRounding.AwayFromZero);
      int y = (int)Math.Round(parElectricBall.Y, MidpointRounding.AwayFromZero);
      if ((x == parX && y+1 == parY) || (x-1 == parX && y+1 == parY) || (x+1 == parX && y+1 == parY)
        || (x-2 == parX && y == parY) || (x-1 == parX && y == parY) || (x == parX && y == parY)
        || (x+1 == parX && y == parY) || (x+2 == parX && y == parY) || (x-1 == parX && y-1 == parY)
        || (x == parX && y-1 == parY) || (x+1 == parX && y-1 == parY))
      {
        return true;
      }
      return false;
    }

    /// <summary>
    /// Задание направления движения влево вверх
    /// </summary>
    public void MovementLeftUp()
    {
      SpaceShip.DirectionType = Enums.DirectionsType.LeftUp;
    }

    /// <summary>
    /// Задание направления движения вправо вверх
    /// </summary>
    public void MovementRightUp()
    {
      SpaceShip.DirectionType = Enums.DirectionsType.RightUp;
    }

    /// <summary>
    /// Задание направления движения влево вниз
    /// </summary>
    public void MovementLeftDown()
    {
      SpaceShip.DirectionType = Enums.DirectionsType.LeftDown;
    }
    /// <summary>
    /// Задание направления движения вправо вниз
    /// </summary>
    public void MovementRightDown()
    {
      SpaceShip.DirectionType = Enums.DirectionsType.RightDown;
    }
  }
}
