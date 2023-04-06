using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask;
public static class SpaceService
{

    public static int CountAsteroidInSpace(this int[][] space)
    {
        var result = 0;
        foreach(var line in space)
            result += line.Count(c => c == 1);

        return result;
    }
}
