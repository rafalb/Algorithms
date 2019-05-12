using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class Graph<T>
    {
        private List<Node<T>> nodes = new List<Node<T>>();

        public IEnumerable<Node<T>> Nodes
        {
            get { return nodes.ToArray(); }
        }

        public Node<T> AddNode(T value, params Node<T>[] neighbours)
        {
            var node = new Node<T>(value, neighbours);
            nodes.Add(node);
            return node;
        }

        public void AddEdge(Node<T> from, Node<T> to)
        {
            if (from != null && to != null)
            {
                from.AddNeighbour(to);
            }
        }
    }
}
