using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class BreadthFirstSearcher<T>
    {
        public IDictionary<Node<T>, int> BreadthFirstSearch(Node<T> startNode)
        {
            var distances = new Dictionary<Node<T>, int>();
            var visited = new HashSet<Node<T>>();
            var queue = new Queue<Node<T>>();

            visited.Add(startNode);
            distances[startNode] = 0;
            queue.Enqueue(startNode);

            while (queue.Any())
            {
                Node<T> node = queue.Dequeue();

                foreach (var neighbour in node.Neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        distances[neighbour] = distances[node] + 1;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return distances;
        }
    }
}
