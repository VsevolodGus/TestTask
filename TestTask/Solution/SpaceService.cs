using System.Runtime.CompilerServices;
using TestTask.Models;

namespace TestTask.Solution;

public class SpaceService
{
    public const int ValuePointAsteroid = 1;

    #region Получение кол-во астероидов
    private readonly List<Node> rootNodes = new();
    
    public int CountAsteroidInSpace(in int[][] space)
    {
        for (int i = 0; i < space.Length; i++)
        {
            for (int j = 0; j < space[i].Length; j++)
            {
                var point = new Point(i, j, space[i][j]);

                if (point.Value == ValuePointAsteroid && !AlreadyExistsPointInAsteroids(point))
                    AddAsteroidInList(space, point);
            }
        }

        return rootNodes.Count;
    }

    private void AddAsteroidInList(int[][] space, in Point point)
    {
        var node = new Node(point);
        rootNodes.Add(node);
        BuildAsteroid(space, node);
    }

    /// <summary>
    /// Собираю дерево из соседних точек, и по ним ищу уже
    /// Можно собирать граф, а не дерево
    /// </summary>
    /// <param name="space"></param>
    /// <param name="node"></param>
    private void BuildAsteroid(int[][] space, Node node)
    {
        var queueNodes = new Queue<Node>();
        do
        {
            var points = space.GetNeighboringPoints(node.Point);

            foreach (var p in points)
            {
                if (AlreadyExistsPointInAsteroids(p))
                    continue;

                var childNode = new Node(p);
                node.Children.Add(childNode);
                queueNodes.Enqueue(childNode);
            }
        } while (queueNodes.TryDequeue(out node));
    }

    private bool AlreadyExistsPointInAsteroids(Point point)
       => rootNodes.Any(c => c.FindPointInTree(point));
    #endregion

    #region Самый короткий путь мимо астероидов

    /// <summary>
    /// Сразу подразумевается, что точка From и TO не является атероидом, позже можно будет добавить проверки на это
    /// Получение самого коротнкого пути от одной точки до другой
    /// 1) самый котороткий путь
    /// 2) если доступного пути нет
    /// Лушче использовать муравьиный алгоритм
    /// </summary>
    /// <param name="space"></param>
    /// <param name="fromPoint"></param>
    /// <param name="toPoint"></param>
    /// <returns>длина пути, если нет доступного пути то возвращается null</returns>
    public int? GetShortWay(int[][] space, Point fromPoint, Point toPoint)
    {
        var node = new Node(fromPoint);

        return 0;
    }

    #endregion
}
