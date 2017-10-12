namespace P08.LinkedQueue.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using P07.LinkedQueue;

    [TestClass]
    public class LinkedQueueTests
    {
        [TestMethod]
        public void LinkedQueue_ParameterlessConstructor_ShouldInitializeCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();

            Assert.AreEqual(0, linkedQueue.Count, "Count was not correct.");
        }

        [TestMethod]
        public void LinkedQueue_ConstructorWithParams_ShouldInitializeCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>(5);

            Assert.AreEqual(1, linkedQueue.Count, "Count was not correct.");
            Assert.AreEqual(5, linkedQueue.Dequeue(), "Initial element was not correct.");
        }

        [TestMethod]
        public void LinkedQueue_EnqueueInEmptyQueue_ShouldAddElementCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Enqueue(5);

            Assert.AreEqual(1, linkedQueue.Count, "Count was not correct.");
            Assert.AreEqual(5, linkedQueue.Dequeue(), "Enqueued element was not correct.");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedQueue_DequeueFromEmptyQueue_ShouldThrow()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Dequeue();
        }

        [TestMethod]
        public void LinkedQueue_DequeueFromNonEmptyQueue_ShouldDequeueElementCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>(5);

            var result = linkedQueue.Dequeue();

            Assert.AreEqual(0, linkedQueue.Count, "Count was not correct.");
            Assert.AreEqual(5, result, "Dequeued element was not correct.");
        }

        [TestMethod]
        public void LinkedQueue_EnqueueDequeue1000Elements_ShouldAddElementsCorrectly()
        {
            var linkedQueue = new LinkedQueue<int>();

            for (int i = 0; i < 1000; i++)
            {
                linkedQueue.Enqueue(i);
                Assert.AreEqual(i + 1, linkedQueue.Count);
            }

            for (int i = 0; i < 1000; i++)
            {
                Assert.AreEqual(i, linkedQueue.Dequeue());
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void LinkedQueue_PeekFromEmptyQueue_ShouldThrow()
        {
            var linkedQueue = new LinkedQueue<int>();

            linkedQueue.Peek();
        }

        [TestMethod]
        public void LinkedQueue_PeekFromNonEmptyQueue_ShouldReturnCorrectElement()
        {
            var linkedQueue = new LinkedQueue<int>(5);

            var result = linkedQueue.Peek();

            Assert.AreEqual(1, linkedQueue.Count, "Count was not correct.");
            Assert.AreEqual(5, result, "Dequeued element was not correct.");
        }

        [TestMethod]
        public void LinkedQueue_ToArrayEmptyQueue_ShouldReturnEmptyArray()
        {
            var linkedQueue = new LinkedQueue<int>();

            var result = linkedQueue.ToArray();
            var expectedArray = new int[] {};

            CollectionAssert.AreEqual(expectedArray, result, "Returned array was not empty.");
        }

        [TestMethod]
        public void LinkedQueue_ToArrayNonEmptyQueue_ShouldReturnCorrectArray()
        {
            var linkedQueue = new LinkedQueue<int>();
            linkedQueue.Enqueue(0);
            linkedQueue.Enqueue(1);
            linkedQueue.Enqueue(2);
            linkedQueue.Enqueue(3);

            var result = linkedQueue.ToArray();
            var expectedArray = new int[] {0, 1, 2, 3};

            CollectionAssert.AreEqual(expectedArray, result, "Returned array was not empty.");
        }
    }
}
