using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Algorithms.Graphs
{
    public class EulerianCycleFinder
    {
        private class Edge<T>
        {
            public Edge(Vertex<T> from, Vertex<T> to)
            {
                From = from;
                To = to;
            }

            public Vertex<T> From { get; private set; }
            public Vertex<T> To { get; private set; }
        }

        public IEnumerable<Vertex<T>> FindEulerianCycleForEulerianGraph<T>(Graph<T> graph)
        {
            // Hierholzer's algorithm

            var cycle = new List<Vertex<T>>();
            var unusedEdges = CreateEdges(graph.Vertices);

            var startVertex = graph.Vertices.FirstOrDefault();
            cycle.Add(startVertex);

            while (startVertex != null)
            {
                var vertex = startVertex;
                var newCycle = new List<Vertex<T>>();

                do
                {
                    var edge = SelectAdjacentUnusedEdge(vertex, unusedEdges);
                    unusedEdges.Remove(edge);

                    vertex = edge.From == vertex ? edge.To : edge.From;
                    newCycle.Add(vertex);
                }
                while (vertex != startVertex);

                MergeCycles(cycle, newCycle, startVertex);
                startVertex = FindVertexWithUnusedEdges<T>(cycle, unusedEdges);
            }

            return cycle;
        }

        private IList<Edge<T>> CreateEdges<T>(IEnumerable<Vertex<T>> vertices)
        {
            var edges = new List<Edge<T>>();

            foreach (var vertex in vertices)
            {
                foreach (var neighbour in vertex.Neighbours)
                {
                    if (!edges.Any(e => e.From == neighbour && e.To == vertex))
                    {
                        edges.Add(new Edge<T>(vertex, neighbour));
                    }
                }
            }

            return edges;
        }

        private Edge<T> SelectAdjacentUnusedEdge<T>(Vertex<T> vertex, IEnumerable<Edge<T>> unusedEdges)
        {
            return unusedEdges.First(e => e.From == vertex || e.To == vertex);
        }

        private Vertex<T> FindVertexWithUnusedEdges<T>(IEnumerable<Vertex<T>> vertices, IEnumerable<Edge<T>> unusedEdges)
        {
            var edge = unusedEdges.FirstOrDefault(e => vertices.Contains(e.From));

            if (edge == null)
            {
                edge = unusedEdges.FirstOrDefault(e => vertices.Contains(e.To));
                return edge == null ? null : edge.To;
            }
            else
            {
                return edge.From;
            }
        }

        private void MergeCycles<T>(List<Vertex<T>> cycle, List<Vertex<T>> newCycle, Vertex<T> startVertex)
        {
            int index = cycle.IndexOf(startVertex);
            cycle.InsertRange(index + 1, newCycle);
        }
    }
}
