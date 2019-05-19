using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs
{
    public class Graph<T>
    {
        private List<Vertex<T>> vertices = new List<Vertex<T>>();

        public IEnumerable<Vertex<T>> Vertices
        {
            get { return vertices.ToArray(); }
        }

        public Vertex<T> GetVertex(T value)
        {
            return vertices.FirstOrDefault(n => n.Value.Equals(value));
        }

        public Vertex<T> AddVertex(T value, params Vertex<T>[] neighbours)
        {
            var vertex = new Vertex<T>(value, neighbours);
            vertices.Add(vertex);
            return vertex;
        }

        public void AddVertices(params T[] values)
        {
            foreach (var value in values)
            {
                AddVertex(value);
            }
        }

        public void AddEdge(Vertex<T> from, Vertex<T> to)
        {
            if (from != null && to != null)
            {
                from.AddNeighbour(to);
            }
        }

        public void AddEdge(T fromValue, T toValue)
        {
            Vertex<T> from = GetVertex(fromValue);
            Vertex<T> to = GetVertex(toValue);

            AddEdge(from, to);
        }
    }
}
