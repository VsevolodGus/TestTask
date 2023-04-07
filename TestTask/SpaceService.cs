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
        var maxX = space.Length;
        var maxY = space.Min(c=> c.Length);
        // TODO добавить логику 
        // нужно добавлять к узлу соседние элементы, делая проверку на кол-во  на ограничения на границы массива
        // делать это в цикле, не в рекурсии

        //up [x][y-1]
        //left [x-1][y]
        //right [x+1][y]
        //down [x][y+1]
        // up left corner [x-1][y-1]
        // up right corner [x+1][y-1]
        // down left corner [x-1][y+1]
        // down right corner [x+1][y+1]
        var queueNodes = new Queue<Node>();
        queueNodes.Enqueue(node);
        do
        {
            //up [x][y-1]
            //left [x-1][y]
            //right [x+1][y]
            //down [x][y+1]
            // up left corner [x-1][y-1]
            // up right corner [x+1][y-1]
            // down left corner [x-1][y+1]
            // down right corner [x+1][y+1]

            if (point.X == 0)
            {
                // do not left [x-1][y]
                // do not up left corner [x-1][y-1]
                // do not down left corner [x-1][y+1]
                queueNodes.Enqueue(node);
            }

            if (point.Y == 0)
            {
                // do not up [x][y-1]
                // do not up left corner [x-1][y-1]
                // do not up right corner [x+1][y-1]
            }

            if (point.X + 1 == maxX)
            {
                // do not left [x-1][y]
                // do not up left corner [x-1][y-1]
                // do not down left corner [x-1][y+1]
            }

            if (point.Y + 1 == maxY)
            {
                // do not down [x][y+1]
                // do not down left corner [x-1][y+1]
                // do not down right corner [x+1][y+1]
            }

        }while(false);
    }

    private static Node GetCall(this int[][] space, int x, int y)
        => new (new Point(x, y, space[x][y]));

}
