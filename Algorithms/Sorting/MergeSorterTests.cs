﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Sorting
{
    [TestFixture]
    internal class MergeSorterTests
    {
        [Test]
        public void ShouldSortEmptyArray()
        {
            var sorter = new MergeSorter<int>();

            int[] items = { };
            sorter.MergeSort(items);

            Assert.IsEmpty(items);
        }

        [Test]
        public void ShouldSortTwoItems()
        {
            var sorter = new MergeSorter<int>();

            int[] items = { 8, 3 };
            sorter.MergeSort(items);

            Assert.AreEqual(new int[] { 3, 8 }, items);
        }

        [Test]
        public void ShouldSortMultipleItems()
        {
            var sorter = new MergeSorter<int>();

            int[] items = { 8, 3, 4, 12, 73, 1, 3, 4, 5 };
            sorter.MergeSort(items);

            Assert.AreEqual(new int[] { 1, 3, 3, 4, 4, 5, 8, 12, 73 }, items);
        }
    }
}
