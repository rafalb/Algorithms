using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class TopologicalSorter
    {
        public IEnumerable<Node<T>> TopologicalSort<T>(Graph<T> graph)
        {
            var visitedNodes = new HashSet<Node<T>>();
            var processedNodes = new Stack<Node<T>>();

            foreach (var node in graph.Nodes)
            {
                if (!visitedNodes.Contains(node))
                {
                    Visit(node, visitedNodes, processedNodes);
                }
            }

            return processedNodes;
        }

        private void Visit<T>(Node<T> node, ISet<Node<T>> visitedNodes, Stack<Node<T>> processedNodes)
        {
            visitedNodes.Add(node);

            foreach (var neighbour in node.Neighbours)
            {
                if (!visitedNodes.Contains(neighbour))
                {
                    Visit(neighbour, visitedNodes, processedNodes);
                }
            }

            processedNodes.Push(node);
        }
    }
}
