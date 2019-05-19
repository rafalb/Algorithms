using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class TopologicalSorter
    {
        public IEnumerable<Vertex<T>> TopologicalSort<T>(Graph<T> graph)
        {
            var visitedVertices = new HashSet<Vertex<T>>();
            var processedVertices = new Stack<Vertex<T>>();

            foreach (var vertices in graph.Vertices)
            {
                if (!visitedVertices.Contains(vertices))
                {
                    Visit(vertices, visitedVertices, processedVertices);
                }
            }

            return processedVertices;
        }

        private void Visit<T>(Vertex<T> vertex, ISet<Vertex<T>> visitedVertices, Stack<Vertex<T>> processedVertices)
        {
            visitedVertices.Add(vertex);

            foreach (var neighbour in vertex.Neighbours)
            {
                if (!visitedVertices.Contains(neighbour))
                {
                    Visit(neighbour, visitedVertices, processedVertices);
                }
            }

            processedVertices.Push(vertex);
        }
    }
}
