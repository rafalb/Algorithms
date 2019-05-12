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

        public Node<T> GetNode(T value)
        {
            return nodes.FirstOrDefault(n => n.Value.Equals(value));
        }

        public Node<T> AddNode(T value, params Node<T>[] neighbours)
        {
            var node = new Node<T>(value, neighbours);
            nodes.Add(node);
            return node;
        }

        public void AddNodes(params T[] values)
        {
            foreach (var value in values)
            {
                AddNode(value);
            }
        }

        public void AddEdge(Node<T> from, Node<T> to)
        {
            if (from != null && to != null)
            {
                from.AddNeighbour(to);
            }
        }

        public void AddEdge(T fromValue, T toValue)
        {
            Node<T> from = GetNode(fromValue);
            Node<T> to = GetNode(toValue);

            AddEdge(from, to);
        }
    }
}
