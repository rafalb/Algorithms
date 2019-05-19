using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Tests
{
    [TestFixture]
    internal class TopologicalSorterTests
    {
        private TopologicalSorter sorter;

        [SetUp]
        public void SetUp()
        {
            sorter = new TopologicalSorter();
        }

        [Test]
        public void ShouldGiveEmptyResultForEmptyGraph()
        {
            var nodes = sorter.TopologicalSort(new Graph<int>());

            Assert.IsEmpty(nodes);
        }

        [Test]
        public void ShouldSortSingleNodeGraph()
        {
            var graph = new Graph<int>();
            var node = graph.AddNode(5);
            var nodes = sorter.TopologicalSort(graph);

            Assert.AreSame(node, nodes.Single());
        }

        [Test]
        public void ShouldSortMultipleNodesGraph()
        {
            var graph = new Graph<char>();
            graph.AddNodes('u', 'v', 'w', 'x', 'y', 'z');
            graph.AddEdge('v', 'y');
            graph.AddEdge('u', 'v');
            graph.AddEdge('u', 'x');
            graph.AddEdge('y', 'x');
            graph.AddEdge('x', 'v');
            graph.AddEdge('z', 'z');
            graph.AddEdge('w', 'z');
            graph.AddEdge('w', 'y');

            var nodes = sorter.TopologicalSort(graph);

            var expected = "wzuvyx";
            var actual = new string(nodes.Select(n => n.Value).ToArray());

            Assert.AreEqual(expected, actual);
        }
    }
}
