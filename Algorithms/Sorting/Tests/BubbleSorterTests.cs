using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms.Sorting.Tests
{
    [TestFixture]
    internal class BubbleSorterTests
    {
        [Test]
        public void ShouldSortEmptyArray()
        {
            var sorter = new BubbleSorter<int>();

            int[] items = { };
            sorter.BubbleSort(items);

            Assert.IsEmpty(items);
        }

        [Test]
        public void ShouldSortTwoItems()
        {
            var sorter = new BubbleSorter<int>();

            int[] items = { 8, 3 };
            sorter.BubbleSort(items);

            Assert.AreEqual(new int[] { 3, 8 }, items);
        }

        [Test]
        public void ShouldSortMultipleItems()
        {
            var sorter = new BubbleSorter<int>();

            int[] items = { 8, 3, 4, 12, 73, 1, 3, 4, 5 };
            sorter.BubbleSort(items);

            Assert.AreEqual(new int[] { 1, 3, 3, 4, 4, 5, 8, 12, 73 }, items);
        }
    }
}
