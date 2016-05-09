namespace P05.OrderedSets_AVLTree_.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using OrderedSet_AVLTree_;

    [TestClass]
    public class AVLRemoveTests
    {
        [TestMethod]
        public void Remove_FromEmptyTree_ShouldReturnFalse()
        {
            var tree = new AvlTree<int>();
            var output = tree.Remove(0);

            Assert.AreEqual(false, output);
        }

        [TestMethod]
        public void Remove_FromTreeWithOneElement_ShouldBecomeEmpty()
        {
            var tree = new AvlTree<int>();
            tree.Add(1);
            var output = tree.Remove(1);

            Assert.AreEqual(true, output);
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Remove_RootWithOneChild_ShouldBecomeEmpty()
        {
            var tree = new AvlTree<int>();
            tree.Add(1);
            tree.Add(3);

            var output = tree.Remove(1);

            Assert.AreEqual(true, output);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Remove_RootWithTwoChildren_ShouldReturnTrue()
        {
            var tree = new AvlTree<int>();
            tree.Add(1);
            tree.Add(3);
            tree.Add(-1);

            var output = tree.Remove(1);

            var nums = TestUtils.ToIntArrayUnique("-1 3");

            var sortedNumbers = nums.OrderBy(n => n).ToArray();
            var expectedSequence = new Queue<int>(sortedNumbers);
            
            tree.ForeachDfs((depth, num) =>
            {
                Assert.AreEqual(expectedSequence.Dequeue(), num);
            });
        }

        [TestMethod]
        public void Remove_Leaf_ShouldReturnTrue()
        {
            var tree = new AvlTree<int>();
            tree.Add(1);
            tree.Add(3);

            var output = tree.Remove(3);

            Assert.AreEqual(true, output);
            Assert.AreEqual(1, tree.Count);
        }

        [TestMethod]
        public void Remove_TwoElements_ShouldReturnTrue()
        {
            var tree = new AvlTree<int>();
            tree.Add(0);
            tree.Add(1);

            var output = tree.Remove(0);
            Assert.AreEqual(true, output);
            Assert.AreEqual(1, tree.Count);

            output = tree.Remove(1);
            Assert.AreEqual(true, output);
            Assert.AreEqual(0, tree.Count);
        }

        [TestMethod]
        public void Remove_MultipleElements_ShouldReturnTrue()
        {
            var treeNums = TestUtils.ToIntArrayUnique("1 5 3 20 6 13 40 70 100 200 -50");
            var numsToRemove = TestUtils.ToIntArrayUnique("1 5 3 20 6");
            var expectedNums = TestUtils.ToIntArrayUnique("13 40 70 100 200 -50");

            var tree = new AvlTree<int>();
            foreach (var num in treeNums)
            {
                tree.Add(num);
            }

            foreach (var num in numsToRemove)
            {
                tree.Remove(num);
            }

            var sortedNumbers = expectedNums.OrderBy(n => n).ToArray();
            var expectedSequence = new Queue<int>(sortedNumbers);

            int count = 0;
            tree.ForeachDfs((depth, num) =>
            {
                Assert.AreEqual(expectedSequence.Dequeue(), num);
                count++;
            });

            Assert.AreEqual(count, tree.Count);
        }
    }
}
