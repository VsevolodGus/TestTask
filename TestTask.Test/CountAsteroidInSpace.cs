namespace TestTask.Test;

public class CountAsteroidInSpace
{
    [Fact]
    public void EmptySpace()
    {
        var space = new int[][] 
        {
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 0, 0},
        };

        Assert.Equal(0, space.CountAsteroidInSpace());
    }

    [Fact]
    public void FullSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 1, 1 },
            new int[] {1, 1, 1 },
            new int[] {1, 1, 1 },
        };

        Assert.Equal(9, space.CountAsteroidInSpace());
    }

    [Fact]
    public void Small5AsteriodInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 0, 0, 0},
            new int[] {0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 0, 1},
            new int[] {0, 0, 1, 0, 0},
            new int[] {0, 0, 0, 0, 1},
        };

        Assert.Equal(5, space.CountAsteroidInSpace());
    }

    [Fact]
    public void GorizontalAndVerticalAsteriodInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 1, 1, 1, 0},
            new int[] {1, 0, 1, 1, 1, 0},
            new int[] {1, 0, 0, 0, 0, 0},
            new int[] {0, 0, 1, 1, 1, 0},
            new int[] {0, 0, 0, 0, 0, 0},
            new int[] {0, 0, 0, 1, 1, 0},
            new int[] {0, 0, 0, 1, 1, 0},
            new int[] {0, 0, 0, 1, 1, 0},
        };

        Assert.Equal(4, space.CountAsteroidInSpace());
    }

    [Fact]
    public void DiagonalAsteriodInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 0, 1, 0},
            new int[] {0, 1, 0, 0, 1},
            new int[] {0, 0, 0, 0, 0},
            new int[] {0, 0, 1, 0, 0},
            new int[] {0, 1, 0, 0, 0},
            new int[] {0, 0, 0, 1, 0},
            new int[] {0, 0, 0, 1, 1},
            new int[] {0, 0, 0, 0, 1},
        };

        Assert.Equal(4, space.CountAsteroidInSpace());
    }

    [Fact]
    public void StrangeFormAsteriodInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 1, 0, 0},
            new int[] {1, 1, 0, 0, 0},
            new int[] {0, 0, 0, 0, 1},
            new int[] {0, 0, 1, 1, 1},
            new int[] {0, 0, 0, 0, 1},
        };

        Assert.Equal(2, space.CountAsteroidInSpace());
    }

    [Fact]
    public void EmptyInsideAsteriodInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 1, 1, 0, 0, 0, 0},
            new int[] {1, 0, 1, 0, 1, 1, 1},
            new int[] {1, 1, 1, 0, 1, 0, 1},
            new int[] {0, 0, 0, 0, 1, 0, 1},
            new int[] {0, 0, 0, 0, 1, 0, 1},
            new int[] {0, 0, 0, 0, 1, 0, 1},
            new int[] {0, 0, 0, 0, 1, 1, 1},
        };

        Assert.Equal(2, space.CountAsteroidInSpace());
    }
}