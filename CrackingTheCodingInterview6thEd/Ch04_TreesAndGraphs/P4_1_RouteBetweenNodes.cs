using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrackingTheCodingInterview6thEd.Ch04_TreesAndGraphs
{
    public class P4_1_RouteBetweenNodes
    {
        public static bool ExistsRoute(Node from, Node to)
        {
            //use breadth first search
            var visitedSet = new HashSet<Node>();
            var queue = new Queue<Node>();
            queue.Enqueue(from);

            while(queue.Count != 0)
            {
                var node = queue.Dequeue();
                if (node == to)
                    return true;

                visitedSet.Add(node);

                foreach (var connection in node.Connections)
                    queue.Enqueue(connection);
            }

            return false;
        }
    }

    public class Node
    {
        public string Name { get; set; }
        public List<Node> Connections { get; set; }

        public Node(string name)
        {
            Name = name;
            Connections = new List<Node>();
        }
    }
}
