using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using P06.ReversedList;

namespace ReversedList.Tests
{
    [TestClass]
    public class ReversedListTests
    {
        private ReversedList<int> reversedList;

        [TestInitialize]
        public void InitializeList()
        {
            reversedList = new ReversedList<int>();
        }

        [TestMethod]
        public void Add_ToEmptyList_ShouldAddCorrectly()
        {
            this.reversedList.Add(5);

            Assert.AreEqual(1, reversedList.Count, "Count was not correct.");
        }

        [TestMethod]
        public void Add_ToNonEmptyList_ShouldAddCorrectly()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            Assert.AreEqual(2, reversedList.Count, "Count was not correct.");
            Assert.AreEqual(3, reversedList[0], "Element at [0] was not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Remove_FromEmptyList_ShouldThrow()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            reversedList.Remove(2);
        }

        [TestMethod]
        public void Remove_FromNonEmptyList_ShouldRemoveCorrectly()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            reversedList.Remove(1);

            Assert.AreEqual(1, reversedList.Count, "Count was not correct.");
        }

        [TestMethod]
        public void Indexer_ShouldGetCorrectElement()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            var itemValueAtZero = reversedList[0];
            var itemValueAtOne = reversedList[1];

            Assert.AreEqual(3, itemValueAtZero, "Element at [0] was not correct.");
            Assert.AreEqual(5, itemValueAtOne, "Element at [1] was not correct.");
        }

        [TestMethod]
        public void Indexer_ShouldSetElementsCorrectly()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            reversedList[0] = 1;
            reversedList[1] = 2;

            var itemValueAtZero = reversedList[0];
            var itemValueAtOne = reversedList[1];

            Assert.AreEqual(1, itemValueAtZero, "Element at [0] was not correct.");
            Assert.AreEqual(2, itemValueAtOne, "Element at [1] was not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Indexer_IncorrectIndex_ShouldThrow()
        {
            reversedList.Add(5);
            reversedList.Add(3);

            reversedList[3] = 1;
        }

        [TestMethod]
        public void Capacity_ShouldExpandListCorrectly()
        {
            for (int item = 0; item <= 17; item++)
            {
                reversedList.Add(item);

                if (item < 16)
                {
                    Assert.AreEqual(16, reversedList.Capacity, "Capacity was not correct.");
                }

                if (item >= 16)
                {
                    Assert.AreEqual(32, reversedList.Capacity, "Capacity was not correct.");
                }
            }

            reversedList[3] = 1;
        }
    }
}
