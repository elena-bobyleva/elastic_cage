using ConsoleView.Game.Entities;
using Model.Game;
using Model.Game.Entities;
using System;
using View.Game;
using View.Game.Entities;

namespace ConsoleView.Game
{
  /// <summary>
  /// Консольное представление окна игры
  /// </summary>
  public class ConsoleGameView : GameView
  {

    /// <summary>
    /// Вывод
    /// </summary>
    private GameOutput _output = GameOutput.GetOut();

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="parGameScreen">окно игры</param>
    public ConsoleGameView(Model.Game.Game parGameScreen) : base(parGameScreen)
    {
    }

    /// <summary>
    /// Отображение игры
    /// </summary>
    public override void Draw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.Clear();
      foreach (EntityView elEntity in Entities)
      {
        elEntity.Draw();
      }
    }

    /// <summary>
    /// Создание представления для сущности
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <returns>представление сущности</returns>
    protected override EntityView CreateEntity(Entity parEntity)
    {
      return new ConsoleEntityView(parEntity);
    }

    /// <summary>
    /// Перерисовывание сущностей
    /// </summary>
    protected override void Redraw()
    {
      Console.BackgroundColor = ConsoleColor.DarkBlue;
      Console.Clear();
      ClearEntities();
      foreach (Entity elEntity in Screen.Entities)
      {
        Entities.Add(CreateEntity(elEntity));
      }
      foreach (EntityView elEntity in Entities)
      {
        elEntity.Draw();
      }
    }
  }
}
