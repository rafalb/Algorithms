using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Tests
{
    [TestFixture]
    internal class GraphTests
    {
        private Graph<int> graph;

        [SetUp]
        public void SetUp()
        {
            graph = new Graph<int>();
        }

        [Test]
        public void ShouldStartEmpty()
        {
            Assert.IsEmpty(graph.Vertices);
        }

        [Test]
        public void ShouldAddNodes()
        {
            var node1 = graph.AddVertex(1);
            var node2 = graph.AddVertex(2);
            var node3 = graph.AddVertex(3, node1, node2);

            var values = graph.Vertices.Select(n => n.Value).ToArray();

            Assert.AreEqual(new int[] { 1, 2, 3 }, values);
        }

        [Test]
        public void ShouldAddEdges()
        {
            var node1 = graph.AddVertex(1);
            var node2 = graph.AddVertex(2);
            var node3 = graph.AddVertex(3, node1);

            graph.AddEdge(node2, node3);
            graph.AddEdge(node1, node3);
            graph.AddEdge(node1, node2);

            Assert.AreEqual(new Vertex<int>[] { node3, node2 }, node1.Neighbours);
        }
    }
}
