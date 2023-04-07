namespace TestTask;

public static class SpaceService
{
    private readonly static List<Node> rootNodes = new ();

    public static int CountAsteroidInSpace(this int[][] space)
    {
        for (int i = 0; i < space.Length; i++)
        {
            for (int j = 0; j < space[i].Length; j++)
            {
                var point = new Point(i, j, space[i][j]);

                if (point.Value == 1 && !AlreadyExistsPointInAsteroids(point))
                    AddAsteroids(space, point);
            }
        }

        return rootNodes.Count;
    }

    private static bool AlreadyExistsPointInAsteroids(Point point)
        => rootNodes.Any(c => c.FindPointInTree(point));

    private static void AddAsteroids(this int[][] space, Point point)
    {
        var node = new Node(point);
        rootNodes.Add(node);

        //TODO добавить логику 
        // нужно добавлять к узлу соседние элементы, делая проверку на кол-во  на ограничения на границы массива
        // делать это в цикле, не в рекурсии
    }
}
