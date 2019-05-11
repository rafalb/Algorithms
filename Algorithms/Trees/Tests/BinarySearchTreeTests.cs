using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Trees.Tests
{
    [TestFixture]
    internal class BinarySearchTreeTests
    {
        private BinarySearchTree<int> tree;

        [SetUp]
        public void SetUp()
        {
            tree = new BinarySearchTree<int>();
        }

        [Test]
        public void ShouldCreateEmptyTree()
        {
            Assert.AreEqual(0, tree.NodeCount);
        }

        [Test]
        public void ShouldAddItemToEmptyTree()
        {
            tree.Add(5);
            Assert.AreEqual(1, tree.NodeCount);
        }

        [Test]
        public void ShouldMakeItemAddedToEmptyTreeTheRoot()
        {
            tree.Add(5);
            Assert.AreEqual(5, tree.RootValue);
        }

        [Test]
        public void ShouldMaintainNodeCountWhenAddingItems()
        {
            tree.Add(5, 3, 8, 2, 5);
            Assert.AreEqual(5, tree.NodeCount);
        }

        [Test]
        public void ShouldReturnTwoSortedItems()
        {
            tree.Add(5, 3);
            int[] sortedValues = tree.GetSortedValues();
            Assert.AreEqual(new int[] { 3, 5 }, sortedValues);
        }

        [Test]
        public void ShouldSortMultipleItems()
        {
            tree.Add(5, 3, 1, 8, 5, 3, 4, 5, 1);
            int[] sortedValues = tree.GetSortedValues();
            Assert.AreEqual(new int[] { 1, 1, 3, 3, 4, 5, 5, 5, 8 }, sortedValues);
        }

        [Test]
        public void ShouldFindItemAddedToTree()
        {
            tree.Add(5, 3, 1, 8, 5, 3, 4, 5, 1);
            Assert.IsTrue(tree.Contains(4));
        }

        [Test]
        public void ShouldNotFindItemNotAddedToTree()
        {
            tree.Add(5, 3, 1, 8, 5, 3, 4, 5, 1);
            Assert.IsFalse(tree.Contains(6));
        }

        [Test]
        public void ShouldRemoveItemFromTree()
        {
            tree.Add(5, 3, 1, 8, 5, 3, 4, 5, 1);
            tree.Remove(4);
            Assert.IsFalse(tree.Contains(4));
        }

        [Test]
        public void ShouldKeepSortedOrderAfterRemovingItem()
        {
            tree.Add(15, 5, 16, 3, 12, 20, 10, 13, 18, 23, 6, 7);
            tree.Remove(6);

            int[] sortedValues = tree.GetSortedValues();
            Assert.AreEqual(new int[] { 3, 5, 7, 10, 12, 13, 15, 16, 18, 20, 23}, sortedValues);
        }

        [Test]
        public void ShouldKeepSortedOrderAfterRemovingRoot()
        {
            tree.Add(15, 5, 16, 3, 12, 20, 10, 13, 18, 23, 6, 7);
            tree.Remove(15);

            int[] sortedValues = tree.GetSortedValues();
            Assert.AreEqual(new int[] { 3, 5, 6, 7, 10, 12, 13, 16, 18, 20, 23 }, sortedValues);
        }
    }
}
