using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Tests
{
    [TestFixture]
    public class BreadthFirstSearcherTests
    {
        [Test]
        public void ShouldSearchGraph()
        {
            var graph = new Graph<char>();
            graph.AddVertices('r', 's', 't', 'u', 'v', 'w', 'x', 'y');
            graph.AddEdge('r', 'v');
            graph.AddEdge('s', 'r');
            graph.AddEdge('s', 'w');
            graph.AddEdge('w', 't');
            graph.AddEdge('w', 'x');
            graph.AddEdge('t', 'x');
            graph.AddEdge('x', 't');
            graph.AddEdge('x', 'y');
            graph.AddEdge('x', 'u');
            graph.AddEdge('t', 'u');
            graph.AddEdge('y', 'u');
            graph.AddEdge('u', 'y');

            var searcher = new BreadthFirstSearcher<char>();
            IDictionary<Vertex<char>, int> distances = searcher.BreadthFirstSearch(graph.GetVertex('s'));

            Assert.AreEqual(3, distances[graph.GetVertex('y')]);
            Assert.AreEqual(2, distances[graph.GetVertex('t')]);
            Assert.AreEqual(1, distances[graph.GetVertex('r')]);
            Assert.AreEqual(1, distances[graph.GetVertex('w')]);
            Assert.AreEqual(2, distances[graph.GetVertex('v')]);
        }
    }
}
