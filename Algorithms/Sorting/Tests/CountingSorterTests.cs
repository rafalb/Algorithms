using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting.Tests
{
    [TestFixture]
    internal class CountingSorterTests
    {
        [Test]
        public void ShouldSortEmptyArray()
        {
            var sorter = new CountingSorter();
            int[] result = sorter.CountingSort(new int[] { }, 5);

            Assert.IsEmpty(result);
        }

        [Test]
        public void ShouldSortSingleItem()
        {
            var sorter = new CountingSorter();
            int[] result = sorter.CountingSort(new int[] { 3 }, 5);

            Assert.AreEqual(3, result[0]);
        }

        [Test]
        public void ShouldCreateSameSizedResult()
        {
            var sorter = new CountingSorter();
            int[] result = sorter.CountingSort(new int[] { 3, 1, 5, 4 }, 5);

            Assert.AreEqual(4, result.Length);
        }
    }
}
