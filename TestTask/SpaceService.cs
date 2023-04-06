using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask;
internal static class SpaceService
{
    private static HashSet<(int, int)> AsteroidCoordinates = new();
    public static int CountAsteroid(int[][] space)
    {
        for (int i = 0; i < space.Length; i++)
        {
            if(space[i].All(c=> c ==  0))
                continue;

            for (int j = 0; j < space[i].Length; j++)
            {
                if (space[i][j] == 0)
                    continue;

                space.ads(i,j);
            }
        }

        return AsteroidCoordinates.Count;
    }

    private static void ads(this int[][] space, int x, int y)
    {
        AsteroidCoordinates.Add((x,y));
    }
}
