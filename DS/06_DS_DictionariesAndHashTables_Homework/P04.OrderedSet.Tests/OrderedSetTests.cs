//namespace P04.OrderedSet.Tests
//{
//    using System.Collections.Generic;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;

//    [TestClass]
//    public class OrderedSetTests
//    {
//        [TestMethod]
//        public void Constructor_Initialize_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            Assert.AreEqual(0, orderedSet.Count, "Count was not correct.");
//        }

//        [TestMethod]
//        public void Add_SingleElement_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            orderedSet.Add(1);

//            Assert.AreEqual(1, orderedSet.Count, "Count should be 1.");
//        }

//        [TestMethod]
//        public void Add_TwoNonUniqueElements_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            orderedSet.Add(1);
//            orderedSet.Add(1);

//            Assert.AreEqual(1, orderedSet.Count, "Count should be 1.");
//        }

//        [TestMethod]
//        public void Add_FiveUniqueAndFiveNonUniqueElements_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            orderedSet.Add(1);
//            orderedSet.Add(2);
//            orderedSet.Add(3);
//            orderedSet.Add(4);
//            orderedSet.Add(5);

//            orderedSet.Add(1);
//            orderedSet.Add(2);
//            orderedSet.Add(3);
//            orderedSet.Add(4);
//            orderedSet.Add(5);

//            Assert.AreEqual(5, orderedSet.Count, "Count should be 5.");
//        }

//        [TestMethod]
//        public void Remove_RemoveNonExistingElement_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            orderedSet.Add(1);
//            orderedSet.Add(2);
//            orderedSet.Add(3);
//            orderedSet.Add(4);
//            orderedSet.Add(5);

//            orderedSet.Remove(10);
//            var list = new List<int>();
//            foreach (var element in orderedSet)
//            {
//                list.Add(element);
//            }

//            Assert.AreEqual(5, orderedSet.Count, "Count should be 5.");
//            CollectionAssert.AreEqual(new List<int>() {1, 2, 3, 4, 5}, list, "Elements were not correct");
//        }

//        [TestMethod]
//        public void Remove_RemoveExistingElement_ShouldHaveCorrectCount()
//        {
//            var orderedSet = new OrderedSet<int>();

//            orderedSet.Add(1);
//            orderedSet.Add(2);
//            orderedSet.Add(3);
//            orderedSet.Add(4);
//            orderedSet.Add(5);

//            orderedSet.Remove(2);
//            orderedSet.Remove(4);
//            var list = new List<int>();
//            foreach (var element in orderedSet)
//            {
//                list.Add(element);
//            }

//            Assert.AreEqual(3, orderedSet.Count, "Count should be 3.");
//            CollectionAssert.AreEqual(new List<int>() { 1, 3, 5 }, list, "Elements were not correct");
//        }

//        [TestMethod]
//        public void Remove_RemoveNodeWithTwoChilds_ShouldHaveCorrectCount()
//        {
//            var set = new OrderedSet<int>();

//            set.Add(17);
//            set.Add(9);
//            set.Add(12);
//            set.Add(19);
//            set.Add(6);
//            set.Add(25);

//            set.Remove(17);
//            var list = new List<int>();
//            foreach (var element in set)
//            {
//                list.Add(element);
//            }

//            Assert.AreEqual(5, set.Count, "Count should be 5.");
//            CollectionAssert.AreEqual(new List<int>() { 6, 9, 12, 19, 25 }, list, "Elements were not correct");
//        }

//        [TestMethod]
//        public void Remove_RemoveNodeWithRightChild_ShouldHaveCorrectCount()
//        {
//            var set = new OrderedSet<int>();

//            set.Add(17);
//            set.Add(9);
//            set.Add(12);
//            set.Add(19);
//            set.Add(6);
//            set.Add(25);

//            set.Remove(19);
//            var list = new List<int>();
//            foreach (var element in set)
//            {
//                list.Add(element);
//            }

//            Assert.AreEqual(5, set.Count, "Count should be 5.");
//            CollectionAssert.AreEqual(new List<int>() { 6, 9, 12, 17, 25 }, list, "Elements were not correct");
//        }

//        [TestMethod]
//        public void Remove_RemoveLeaf_ShouldHaveCorrectCount()
//        {
//            var set = new OrderedSet<int>();

//            set.Add(17);
//            set.Add(9);
//            set.Add(12);
//            set.Add(19);
//            set.Add(6);
//            set.Add(25);

//            set.Remove(25);
//            var list = new List<int>();
//            foreach (var element in set)
//            {
//                list.Add(element);
//            }

//            Assert.AreEqual(5, set.Count, "Count should be 5.");
//            CollectionAssert.AreEqual(new List<int>() { 6, 9, 12, 17, 19 }, list, "Elements were not correct");
//        }
//    }
//}
