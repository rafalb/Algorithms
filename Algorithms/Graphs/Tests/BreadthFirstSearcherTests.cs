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
            graph.AddNodes('r', 's', 't', 'u', 'v', 'w', 'x', 'y');
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
            IDictionary<Node<char>, int> distances = searcher.BreadthFirstSearch(graph.GetNode('s'));

            Assert.AreEqual(3, distances[graph.GetNode('y')]);
            Assert.AreEqual(2, distances[graph.GetNode('t')]);
            Assert.AreEqual(1, distances[graph.GetNode('r')]);
            Assert.AreEqual(1, distances[graph.GetNode('w')]);
            Assert.AreEqual(2, distances[graph.GetNode('v')]);
        }
    }
}
