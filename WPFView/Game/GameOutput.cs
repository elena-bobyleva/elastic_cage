using Model.Enums;
using Model.Game.Entities;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WPFView.Game
{
  /// <summary>
  /// Класс для задание формы сущностям
  /// </summary>
  public class GameOutput
  {
    /// <summary>
    /// Создание представления сущности
    /// </summary>
    /// <param name="parEntity">сущность</param>
    /// <returns>представление сущности</returns>
    public static Shape CreateViewEntity(Entity parEntity)
    {
      Shape shape = null;

      if (parEntity.EntityType == EntitiesType.SpaceShip)
      {
        shape = CreateRectangle(parEntity.X, parEntity.Y, 30, 30);
        //shape = CreateSpaceShip(parEntity.DirectionType, parEntity.X, parEntity.Y, 30);
      }

      if (parEntity.EntityType == EntitiesType.ElectricBall)
      {
        shape = CreateElectricBall(parEntity.X, parEntity.Y, 40, 48);
        shape.Fill = new SolidColorBrush(Colors.White);
        shape.Stroke = new SolidColorBrush(Colors.White);
      }    
      
      return shape;
    }

    /// <summary>
    /// Создание космического корабля(прямоугольник)
    /// </summary>
    /// <param name="parX">координата х</param>
    /// <param name="parY">координата у</param>
    /// <param name="parWidth">ширина прямоугольника</param>
    /// <param name="parHeight">высота прямоугольника</param>
    /// <returns>представление космического корабля в виде прямоугольника</returns>
    private static Shape CreateRectangle(double parX, double parY, double parWidth, double parHeight)
    {
      Rectangle rectangle = new Rectangle();
      rectangle.Width = parWidth;
      rectangle.Height = parHeight;
      rectangle.StrokeThickness = 3;
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush();
      linearGradientBrush.StartPoint = new Point(0, 0);
      linearGradientBrush.EndPoint = new Point(1,1);
      linearGradientBrush.GradientStops.Add(new GradientStop(Colors.White, 0.0));
      linearGradientBrush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 0.6));
      linearGradientBrush.GradientStops.Add(new GradientStop(Colors.DarkBlue, 1.0));
      rectangle.Fill = linearGradientBrush;
      Canvas.SetTop(rectangle, parY);
      Canvas.SetLeft(rectangle, parX);
      return rectangle;
    }

    /// <summary>
    /// Создание космического корабля(треугольника)
    /// </summary>
    /// <param name="parDirection">направление движения</param>
    /// <param name="parX">координата х левого верхнего угла</param>
    /// <param name="parY">координата у левого верхнего угла</param>
    /// <param name="parSize">размер</param>
    /// <returns>представление космического корабля</returns>
    public static Shape CreateSpaceShip(DirectionsType parDirection, double parX, double parY, double parSize)
    {
      PointCollection points = GetCoordinateShip(parDirection, parX, parY, parSize);
      Polyline polygon = new Polyline();
      polygon.StrokeThickness = 1;
      polygon.Points = points;
      return polygon;
    }


    /// <summary>
    /// Получает координаты корабля в зависимости от направления движения
    /// </summary>
    /// <param name="parDirection">направление движения</param>
    /// <param name="parX">координата х левого верхнего угла</param>
    /// <param name="parY">координата у левого верхнего угла</param>
    /// <param name="parSize">размер треугольника</param>
    /// <returns>вершины треугольника</returns>
    private static PointCollection GetCoordinateShip(DirectionsType parDirection, double parX, double parY, double parSize)
    {
      PointCollection points = new PointCollection();
      points.Add(new Point(parX, parY));
      points.Add(new Point(parX, parY+parSize));
      points.Add(new Point(parX+parSize, parY));
      /*switch (parDirection)
      {
        case DirectionsType.STOP:
          points.Add(new Point(parX-k, parY-k));
          points.Add(new Point(parX-k, parY-k+parSize));
          points.Add(new Point(parX-k+parSize, parY-k));
          break;
        case DirectionsType.LEFT_UP:
          points.Add(new Point(parX-k, parY-k));
          points.Add(new Point(parX-k, parY-k+parSize));
          points.Add(new Point(parX-k+parSize, parY-k));
          break;
        case DirectionsType.LEFT_DOWN:
          points.Add(new Point(parX-k, parY+k));
          points.Add(new Point(parX-k, parY+k-parSize));
          points.Add(new Point(parX-k+parSize, parY+k));
          break;
        case DirectionsType.RIGHT_DOWN:
          points.Add(new Point(parX+k, parY+k));
          points.Add(new Point(parX+k, parY+k-parSize));
          points.Add(new Point(parX+k-parSize, parY+k));
          break;
        case DirectionsType.RIGHT_UP:
          points.Add(new Point(parX+k, parY-k));
          points.Add(new Point(parX+k, parY-k+parSize));
          points.Add(new Point(parX+k-parSize, parY-k));
          break;
      }*/
      return points;
    }

    /// <summary>
    /// Создание электрического шара
    /// </summary>
    /// <param name="parX">координата х центра</param>
    /// <param name="parY">координата у центра</param>
    /// <param name="parWidth">ширина эллипса</param>
    /// <param name="parHeight">высота эллипса</param>
    /// <returns>представление электрического шара</returns>
    private static Shape CreateElectricBall(double parX, double parY, double parWidth, double parHeight)
    {
      Ellipse ellipse = new Ellipse();
      ellipse.StrokeThickness = 1;
      ellipse.Height = parHeight;
      ellipse.Width = parWidth;
      Canvas.SetTop(ellipse, parY - parHeight / 2);
      Canvas.SetLeft(ellipse, parX - parWidth / 2);
      return ellipse;
    }

    /// <summary>
    /// Создание границ поля
    /// </summary>
    /// <param name="parX">координата х верхнего левого угла</param>
    /// <param name="parY">координата у верхнего левого угла</param>
    /// <param name="parWidth">ширина поля</param>
    /// <param name="parHeight">высота поля</param>
    /// <returns></returns>
    public static Shape CreateField(double parX, double parY, double parWidth, double parHeight)
    {
      Shape field = new Rectangle();
      field.Width = parWidth;
      field.Height = parHeight;
      field.StrokeThickness = 3;
      field.Stroke = new SolidColorBrush(Colors.White);
      Canvas.SetTop(field, parY);
      Canvas.SetLeft(field, parX);
      return field;
    }
  }
}
