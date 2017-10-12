using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P07.LinkedList.Tests
{
    using System;

    [TestClass]
    public class LinkedListTests
    {
        private LinkedList<int> linkedList;

        [TestInitialize]
        public void InitializeLinkedList()
        {
            this.linkedList = new LinkedList<int>();
        }

        [TestMethod]
        public void Add_EmptyList_ShouldAddCorrectly()
        {
            linkedList.Add(3);

            Assert.AreEqual(1, linkedList.Count, "Count was not correct.");
        }

        [TestMethod]
        public void Add_NonEmptyList_ShouldAddCorrectly()
        {
            linkedList.Add(3);
            linkedList.Add(3);

            Assert.AreEqual(2, linkedList.Count, "Count was not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_EmptyList_ShouldThrow()
        {
            linkedList.Remove(2);
        }

        [TestMethod]
        public void Remove_NonEmptyList_ShouldRemoveCorrectly()
        {
            linkedList.Add(0);
            linkedList.Add(1);
            linkedList.Add(2);

            var result = linkedList.Remove(1);

            Assert.AreEqual(2, linkedList.Count, "Count was not correct.");
            Assert.AreEqual(1, result, "Returned item was not correct.");
        }

        [TestMethod]
        public void FirstIndexOf_NonEmptyList_ShouldRemoveCorrectly()
        {
            linkedList.Add(0);
            linkedList.Add(0);
            linkedList.Add(0);

            var result = linkedList.FirstIndexOf(0);
            
            Assert.AreEqual(0, result, "Returned index was not correct.");
        }

        [TestMethod]
        public void LastIndexOf_NonEmptyList_ShouldRemoveCorrectly()
        {
            linkedList.Add(0);
            linkedList.Add(0);
            linkedList.Add(0);

            var result = linkedList.LastIndexOf(0);

            Assert.AreEqual(2, result, "Returned index was not correct.");
        }
    }
}
