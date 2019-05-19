using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class BreadthFirstSearcher<T>
    {
        public IDictionary<Vertex<T>, int> BreadthFirstSearch(Vertex<T> startVertex)
        {
            var distances = new Dictionary<Vertex<T>, int>();
            var visited = new HashSet<Vertex<T>>();
            var queue = new Queue<Vertex<T>>();

            visited.Add(startVertex);
            distances[startVertex] = 0;
            queue.Enqueue(startVertex);

            while (queue.Any())
            {
                Vertex<T> vertex = queue.Dequeue();

                foreach (var neighbour in vertex.Neighbours)
                {
                    if (!visited.Contains(neighbour))
                    {
                        visited.Add(neighbour);
                        distances[neighbour] = distances[vertex] + 1;
                        queue.Enqueue(neighbour);
                    }
                }
            }

            return distances;
        }
    }
}
