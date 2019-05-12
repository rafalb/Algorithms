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
            Assert.IsEmpty(graph.Nodes);
        }
    }
}
