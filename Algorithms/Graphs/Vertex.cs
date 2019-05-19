using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class Vertex<T>
    {
        private T value;
        private List<Vertex<T>> neighbours = new List<Vertex<T>>();

        public Vertex(T value, IEnumerable<Vertex<T>> neighbours)
        {
            this.value = value;
            this.neighbours.AddRange(neighbours);
        }

        public T Value
        {
            get { return value; }
        }

        public IEnumerable<Vertex<T>> Neighbours
        {
            get { return neighbours; }
        }

        public void AddNeighbour(Vertex<T> neighbour)
        {
            neighbours.Add(neighbour);
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
