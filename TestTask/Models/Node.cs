namespace TestTask.Models;
internal class Node
{
    public Node(Point point)
    {
        Point = point;
        Children = new List<Node>();
    }

    public Node(Node node)
    {
        Point = node.Point;
        Children = node.Children;
    }

    public Point Point { get; }

    public ICollection<Node> Children { get; }

}

