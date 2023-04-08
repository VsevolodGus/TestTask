using TestTask.Models;

namespace TestTask.Solution;

internal static class NodeExtension
{
    public static bool FindPointInTree(this Node root, Point findPoint)
    {
        var rootNode = new Node(root);
        var parents = new Queue<Node>();
        parents.Enqueue(rootNode);
        do
        {
            if (rootNode.Point.Equals(findPoint))
                return true;

            foreach (var item in rootNode.Children)
                parents.Enqueue(item);

        } while (parents.TryDequeue(out rootNode));

        return false;
    }
}
