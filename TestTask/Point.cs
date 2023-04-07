namespace TestTask;
internal class Point
{
    public Point(int x, int y, int value = 1)
    {
        X = x;
        Y = y;
        Value = value;
    }

    public int X { get; }

    public int Y { get; }

    public int Value { get; }

    public bool Equals(Point point)
        => X == point.X && Y == point.Y;
}