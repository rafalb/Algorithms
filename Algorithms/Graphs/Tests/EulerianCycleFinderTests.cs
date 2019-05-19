using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Graphs.Tests
{
    [TestFixture]
    public class EulerianCycleFinderTests
    {
        [Test]
        public void ShouldFindEulerianCycle()
        {
            // Create graph from this picture: https://upload.wikimedia.org/wikipedia/commons/thumb/7/72/Labelled_Eulergraph.svg/800px-Labelled_Eulergraph.svg.png
            var graph = new Graph<int>();
            graph.AddVertices(1, 2, 3, 4, 5, 6);
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 6);
            graph.AddEdge(2, 1);
            graph.AddEdge(2, 3);
            graph.AddEdge(2, 4);
            graph.AddEdge(3, 5);
            graph.AddEdge(3, 2);
            graph.AddEdge(3, 4);
            graph.AddEdge(3, 6);
            graph.AddEdge(4, 3);
            graph.AddEdge(4, 2);
            graph.AddEdge(4, 6);
            graph.AddEdge(4, 5);
            graph.AddEdge(5, 1);
            graph.AddEdge(5, 4);
            graph.AddEdge(5, 3);
            graph.AddEdge(5, 6);
            graph.AddEdge(6, 4);
            graph.AddEdge(6, 2);
            graph.AddEdge(6, 3);
            graph.AddEdge(6, 5);

            var cycleFinder = new EulerianCycleFinder();
            var cycle = cycleFinder.FindEulerianCycleForEulerianGraph(graph);

            var expected = new int[] { 1, 2, 6, 3, 2, 4, 6, 5, 4, 3, 5, 1 };
            var actual = cycle.Select(v => v.Value).ToArray();

            Assert.AreEqual(expected, actual);
        }
    }
}
