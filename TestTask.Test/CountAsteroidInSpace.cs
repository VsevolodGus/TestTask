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

        var spaceService = new SpaceService();
        Assert.Equal(0, spaceService.CountAsteroidInSpace(space));
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

        var spaceService = new SpaceService();
        Assert.Equal(1, spaceService.CountAsteroidInSpace(space));
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

        var spaceService = new SpaceService();
        Assert.Equal(5, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void VerticalAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 0 },
            new int[] {1, 0, 0 },
            new int[] {1, 0, 0 },
        };

        var spaceService = new SpaceService();
        Assert.Equal(1, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void SeveralVerticalAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 0, 1, 1 },
            new int[] {1, 0, 0, 1, 1 },
            new int[] {1, 0, 0, 1, 1 },
            new int[] {1, 0, 0, 1, 1 },
            new int[] {1, 0, 0, 0, 0 },
        };

        var spaceService = new SpaceService();
        Assert.Equal(2, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void HorizontalAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 1, 1 },
            new int[] {0, 0, 0 },
            new int[] {0, 0, 0 },
        };

        var spaceService = new SpaceService();
        Assert.Equal(1, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void SeveralHorizontalAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 1, 1, 0, 0, },
            new int[] {0, 0, 0, 0, 0, },
            new int[] {1, 1, 1, 1, 0, },
            new int[] {1, 1, 1, 1, 0, },
            new int[] {0, 0, 0, 0, 0, },
            new int[] {0, 0, 0, 1, 1, },
        };

        var spaceService = new SpaceService();
        Assert.Equal(3, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void DiagonalAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 0, 0, 1},
            new int[] {0, 1, 0, 1, 0},
            new int[] {0, 0, 0, 0, 0},
        };

        var spaceService = new SpaceService();
        Assert.Equal(2, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void StrangeFormAsteroidInSpace()
    {
        var space = new int[][]
        {
            new int[] {1, 0, 1, 0, 0},
            new int[] {1, 1, 0, 0, 0},
            new int[] {0, 0, 0, 0, 1},
            new int[] {0, 1, 1, 1, 1},
            new int[] {1, 0, 0, 0, 1},
        };

        var spaceService = new SpaceService();
        Assert.Equal(2, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void EmptyInsideAsteroidInSpace()
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

        var spaceService = new SpaceService();
        Assert.Equal(2, spaceService.CountAsteroidInSpace(space));
    }

    [Fact]
    public void DataFromFile()
    {
        var space = new int[][]
        {
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,1,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,1,0,0,0,0,1,0,1,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,1,0,0,0,0,1,1,1,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,1 },
            new int[] { 0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
            new int[] { 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,1,1,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
            new int[] { 0,0,0,0,1,0,0,0,0,0,0,0,0,0,0,0,0,0,1,0 },
            new int[] { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
        };

        var spaceService = new SpaceService();
        Assert.Equal(8, spaceService.CountAsteroidInSpace(space));
    }



}