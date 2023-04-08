using TestTask.Models;

namespace TestTask.Solution;

internal static class NodeExtension
{
    /// <summary>
    /// Можно оптимизировать сделав логику поиска на подобие бинарного дерева
    /// мол findPoint.X > rootNode.Point.X, то берем только детей у которых X больше текущего
    /// аналогично с Y
    /// Если findPoint.X < rootNode.Point.X, то берем меньше
    /// </summary>
    /// <param name="root"></param>
    /// <param name="findPoint"></param>
    /// <returns></returns>
    public static bool FindPointInTree(this Node root, in Point findPoint)
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
