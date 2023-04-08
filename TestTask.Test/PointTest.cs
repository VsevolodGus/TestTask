namespace TestTask.Test;
public class PointTest
{
    [Fact]
    public void TruePoint()
    {
        var firstPoint = new Point(1, 1);

        Assert.True(firstPoint.Equals(new Point(1,1)));
    }

    [Fact]
    public void FalsePoint()
    {
        var firstPoint = new Point(1, 1);

        Assert.False(firstPoint.Equals(new Point(1, 2)));
    }
}
