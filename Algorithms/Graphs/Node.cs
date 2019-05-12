using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class Node<T>
    {
        private T value;
        private List<Node<T>> neighbours = new List<Node<T>>();

        public Node(T value, IEnumerable<Node<T>> neighbours)
        {
            this.value = value;
            this.neighbours.AddRange(neighbours);
        }

        public T Value
        {
            get { return value; }
        }

        public IEnumerable<Node<T>> Neighbours
        {
            get { return neighbours; }
        }

        public void AddNeighbour(Node<T> neighbour)
        {
            neighbours.Add(neighbour);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
