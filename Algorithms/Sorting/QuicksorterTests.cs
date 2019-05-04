using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    [TestFixture]
    internal class QuicksorterTests
    {
        [Test]
        public void ShouldSortEmptyArray()
        {
            var sorter = new Quicksorter<int>();

            int[] items = { };
            sorter.Quicksort(items);

            Assert.IsEmpty(items);
        }

        [Test]
        public void ShouldSortTwoItems()
        {
            var sorter = new Quicksorter<int>();

            int[] items = { 8, 3 };
            sorter.Quicksort(items);

            Assert.AreEqual(new int[] { 3, 8 }, items);
        }

        [Test]
        public void ShouldSortMultipleItems()
        {
            var sorter = new Quicksorter<int>();

            int[] items = { 8, 3, 4, 12, 73, 1, 3, 4, 5 };
            sorter.Quicksort(items);

            Assert.AreEqual(new int[] { 1, 3, 3, 4, 4, 5, 8, 12, 73 }, items);
        }
    }
}
