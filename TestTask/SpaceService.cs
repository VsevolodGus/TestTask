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

                if (point.Value == 1)
                {
                }


                if (point.Value == 1 && !AlreadyExistsPointAsteroid(point))
                    rootNodes.Add(new Node(point));
            }
        }

        return rootNodes.Count;
    }

    private static bool AlreadyExistsPointAsteroid(Point point)
        => rootNodes.Any(c => c.FindPointInTree(point));
}
