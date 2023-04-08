using TestTask.Models;
using TestTask.Solution;

namespace TestTask.Solution;

internal static class SpaceExtension
{

    internal static Point[] GetNeighboringPoints(this int[][] space, Point point)
    {
        var queue = new Queue<Point>();

        //up [x][y-1]
        queue.Enqueue(space.GetPointByCoordinate(point.X, point.Y - 1));

        //left [x-1][y]
        queue.Enqueue(space.GetPointByCoordinate(point.X - 1, point.Y));

        //right [x+1][y]
        queue.Enqueue(space.GetPointByCoordinate(point.X + 1, point.Y));

        //down [x][y+1]
        queue.Enqueue(space.GetPointByCoordinate(point.X, point.Y + 1));

        // up left corner [x-1][y-1]
        queue.Enqueue(space.GetPointByCoordinate(point.X - 1, point.Y - 1));

        // up right corner [x+1][y-1]
        queue.Enqueue(space.GetPointByCoordinate(point.X + 1, point.Y - 1));

        // down left corner [x-1][y+1]
        queue.Enqueue(space.GetPointByCoordinate(point.X - 1, point.Y + 1));

        // down right corner [x+1][y+1]
        queue.Enqueue(space.GetPointByCoordinate(point.X + 1, point.Y + 1));


        return queue.Where(c => c != null && c.Value == SpaceService.ValuePointAsteroid).ToArray();
    }

    private static Point GetPointByCoordinate(this int[][] space, int x, int y)
    {
        var maxX = space.Length;
        var maxY = space.Max(c => c.Length);

        // 0 < y < maxY
        // 0 < x < maxX
        // если нарушает то null, который потом обрабатывается
        if (y >= maxY || x >= maxX
            || y < 0 || x < 0)
            return null;

        return new Point(x, y, space[x][y]);
    }
}
