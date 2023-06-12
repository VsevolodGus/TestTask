namespace TestTask.Models;

public class Node
{
    public Node() 
    { }

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

    public Point Point { get; init; }

    public ICollection<Node> Children { get; init; }

}

