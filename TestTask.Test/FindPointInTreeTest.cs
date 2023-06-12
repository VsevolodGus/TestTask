using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestTask.Test;
public class FindPointInTreeTest
{

    /// <summary>
    /// 0 0
    /// 0 0
    /// </summary>
    [Fact]
    public void HasNot_False()
    {

        var point00 = new Point(0, 0);
        var point10 = new Point(1, 0);
        var point01 = new Point(0, 1);
        var point11 = new Point(1, 1);

        var node00 = new Node() 
        { 
            Point = point00,
            Children = new List<Node>() 
            {
                new Node(point11),
                new Node(point10),
                new Node(point01),
            },
        };

        var node10 = new Node()
        {
            Point = point10,
            Children = new List<Node>()
            {
                new Node(point11),
                new Node(point00),
                new Node(point01),
            },
        };

        var node01 = new Node()
        {
            Point = point01,
            Children = new List<Node>()
            {
                new Node(point11),
                new Node(point00),
                new Node(point10),
            },
        };

        var node11 = new Node()
        {
            Point = point01,
            Children = new List<Node>()
            {
                new Node(point01),
                new Node(point00),
                new Node(point10),
            },
        };

        var node = new Node(node00)
        {
            Children = new Node[] 
            {
                node01, node10, node11
            }
        };

        var result = node.HasCycle();
        Assert.True(result);
    }
}
