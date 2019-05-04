using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Algorithms.Sorting
{
    [TestFixture]
    internal class InsertionSorterTests
    {
        [Test]
        public void ShouldSortEmptyArray()
        {
            var sorter = new InsertionSorter<int>();

            int[] items = { };
            sorter.InsertionSort(items);

            Assert.IsEmpty(items);
        }

        [Test]
        public void ShouldSortTwoItems()
        {
            var sorter = new InsertionSorter<int>();

            int[] items = { 8, 3 };
            sorter.InsertionSort(items);

            Assert.AreEqual(new int[] { 3, 8 }, items);
        }

        [Test]
        public void ShouldSortMultipleItems()
        {
            var sorter = new InsertionSorter<int>();

            int[] items = { 8, 3, 4, 12, 73, 1, 3, 4, 5 };
            sorter.InsertionSort(items);

            Assert.AreEqual(new int[] { 1, 3, 3, 4, 4, 5, 8, 12, 73 }, items);
        }
    }
}
