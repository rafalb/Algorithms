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
        private Node<T>[] neighbours;

        public Node(T value, IEnumerable<Node<T>> neighbours)
        {
            this.value = value;
            this.neighbours = neighbours.ToArray();
        }

        public T Value
        {
            get { return value; }
        }

        public IEnumerable<Node<T>> Neighbours
        {
            get { return neighbours; }
        }
    }
}
