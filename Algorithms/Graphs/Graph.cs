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

        public void AddNode(T value, params Node<T>[] neighbours)
        {
            var node = new Node<T>(value, neighbours);
        }

        public void AddEdge(Node<T> from, Node<T> to, bool bidirectional)
        {
            if (from != null && to != null && nodes.Remove(from) && nodes.Remove(to))
            {
                List<Node<T>> newNeighbours = new List<Node<T>>(from.Neighbours);
                newNeighbours.Add(to);

                Node<T> new1 = new Node<T>(from.Value, newNeighbours);
                nodes.Add(new1);

                newNeighbours = new List<Node<T>>(to.Neighbours);

                if (bidirectional)
                {
                    newNeighbours.Add(from);
                }

                Node<T> new2 = new Node<T>(to.Value, newNeighbours);
                nodes.Add(new2);
            }
        }
    }
}
