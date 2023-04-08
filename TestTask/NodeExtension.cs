namespace TestTask;

internal static class NodeExtension
{
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
