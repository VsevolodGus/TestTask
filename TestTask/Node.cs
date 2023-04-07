namespace TestTask;
internal class Node
{
    public Node(int x, int y)
    {
        Point = new Point(x, y);
    }

    public Node(Point point)
    {
        Point = point;
    }

    public Node(Node node)
    {
        Point = node.Point;
        Children = node.Children;
    }

    public Point Point { get; }

    public ICollection<Node> Children { get; } = new List<Node>();

}

