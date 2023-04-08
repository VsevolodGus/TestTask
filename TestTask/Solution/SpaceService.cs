using TestTask.Models;
using TestTask.Solution;

namespace TestTask.Solution;

public class SpaceService
{
    private readonly List<Node> rootNodes = new();
    public const int ValuePointAsteroid = 1;
    public int CountAsteroidInSpace(int[][] space)
    {
        for (int i = 0; i < space.Length; i++)
        {
            for (int j = 0; j < space[i].Length; j++)
            {
                var point = new Point(i, j, space[i][j]);

                if (point.Value == ValuePointAsteroid && !AlreadyExistsPointInAsteroids(point))
                    AddAsteroids(space, point);
            }
        }

        return rootNodes.Count;
    }

    private bool AlreadyExistsPointInAsteroids(Point point)
        => rootNodes.Any(c => c.FindPointInTree(point));

    private void AddAsteroids(int[][] space, Point point)
    {
        var node = new Node(point);
        rootNodes.Add(node);

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
}
