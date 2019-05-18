using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.DynamicProgramming.Tests
{
    [TestFixture]
    internal class LongestCommonSubsequenceRecursiveTests
    {
        private LongestCommonSubsequenceRecursive subsequenceFinder;

        [SetUp]
        public void SetUp()
        {
            subsequenceFinder = new LongestCommonSubsequenceRecursive();
        }

        [Test]
        public void ShouldReturnEmptyForEmptyInput()
        {
            string subsequence = subsequenceFinder.FindLongestCommonSubsequence(String.Empty, "Test");
            Assert.IsEmpty(subsequence);
        }

        [Test]
        public void ShouldFindLongestSubsequence()
        {
            string subsequence = subsequenceFinder.FindLongestCommonSubsequence("Test car", "estimator");
            Assert.AreEqual("estar", subsequence);
        }

        [Test]
        public void ShouldFindLongestSubsequenceForLongStrings()
        {
            string subsequence = subsequenceFinder.FindLongestCommonSubsequence("ACCGGTCGAGTGCGCGGAA", "GTCGTTCGGAATGC");
            Assert.AreEqual("GTCGTCGGAA", subsequence);
        }
    }
}
