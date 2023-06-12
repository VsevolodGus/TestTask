using System.Net;
using TestTask.Models;

namespace TestTask.Solution;

public static class NodeExtension
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
        // узел для которого которого в котором происходит поиск
        var rootNode = new Node(root);
        // узлы которые нужно будет еще проверить
        var parents = new Queue<Node>();
        // посещенные узлы, для защиты от циклов
        var visited = new Queue<Point>();

        parents.Enqueue(rootNode);
        do
        {
            if (rootNode.Point.Equals(findPoint))
                return true;

            visited.Enqueue(rootNode.Point);

            foreach (var item in rootNode.Children)
            {
                if(visited.Contains(item.Point))
                    continue;

                parents.Enqueue(item);
            }

        } while (parents.TryDequeue(out rootNode));

        return false;
    }

    public static bool HasCycle(this Node root)
    {
        // узел для которого которого в котором происходит поиск
        var rootNode = new Node(root);
        // узлы которые нужно будет еще проверить
        var parents = new Queue<Node>();
        // посещенные узлы, для защиты от циклов
        var visited = new Queue<Point>();

        parents.Enqueue(rootNode);
        do
        {
            if(visited.Contains(rootNode.Point))
                return true;

            visited.Enqueue(rootNode.Point);

            foreach (var item in rootNode.Children)
            {
                if (visited.Contains(item.Point))
                    continue;

                parents.Enqueue(item);
            }

        } while (parents.TryDequeue(out rootNode));

        return false;
    }
}
