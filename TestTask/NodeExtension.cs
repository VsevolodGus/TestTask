namespace TestTask;

internal static class NodeExtension
{
    public static Node[] GetTreeInWidth(this Node root)
    {
        var rootNode = new Node(root);
        var parents = new Queue<Node>();
        var nodes = new Queue<Node>();
        nodes.Enqueue(rootNode);

        do
        {
            foreach (var item in rootNode.Children)
            {
                nodes.Enqueue(item);
                parents.Enqueue(item);
            }
        }while(parents.TryDequeue(out rootNode));

        return nodes.ToArray();
    }

    public static bool FindPointInTree(this Node root, Point findPoint)
    {
        var rootNode = new Node(root);
        if(rootNode.Point.Equals(findPoint))
            return true;

        var parents = new Queue<Node>();
        do
        {
            foreach (var item in rootNode.Children)
            {
                if (item.Point.Equals(findPoint))
                    return true;
                parents.Enqueue(item);
            }
        } while (parents.TryDequeue(out rootNode));

        return false;
    }
}
