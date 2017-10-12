using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P04.ArrayBasedStack.Tests
{
    using P03.ArrayBasedStack;

    [TestClass]
    public class ArrayBasedStackTests
    {
        [TestMethod]
        public void ArrayBasedStack_Push_AddOneElementToEmptyStack_CountShouldBecomeOne()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(5);

            Assert.AreEqual(1, arrayStack.Count);
        }

        [TestMethod]
        public void ArrayBasedStack_Push_WithInitialCapacityOne_ShouldPushAndIncreaseCapacityCorrectly()
        {
            var arrayStack = new ArrayStack<int>(1);

            Assert.AreEqual(0, arrayStack.Count, "Initial count was not correct.");
            Assert.AreEqual(1, arrayStack.Capacity, "Initial capacity was not correct.");

            arrayStack.Push(5);
            
            Assert.AreEqual(1, arrayStack.Count, "First push() count was not correct.");
            Assert.AreEqual(1, arrayStack.Capacity, "First push() capacity was not correct.");

            arrayStack.Push(5);

            Assert.AreEqual(2, arrayStack.Count, "Second push() count was not correct.");
            Assert.AreEqual(2, arrayStack.Capacity, "First push() capacity was not correct.");
        }

        [TestMethod]
        public void ArrayBasedStack_Push_1000ElementsToEmptyStack_ShouldAddCorrectly()
        {
            var arrayStack = new ArrayStack<int>();
            for (int i = 0; i < 1000; i++)
            {
                arrayStack.Push(i);
                Assert.AreEqual(i + 1, arrayStack.Count, "Count on push was not correct.");
            }

            for (int i = 1000; i > 0; i--)
            {
                Assert.AreEqual(i, arrayStack.Count, "Count on pop was not correct.");
                var poppedElement = arrayStack.Pop();
                Assert.AreEqual(i - 1, poppedElement, "Popped element was not correct.");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ArrayBasedStack_Pop_OneElementToEmptyStack_ShouldThrow()
        {
            var arrayStack = new ArrayStack<int>();

            arrayStack.Pop();
        }

        [TestMethod]
        public void ArrayBasedStack_Pop_OneElementFromNonEmptyStack_ShouldReturnElement()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(5);

            var result = arrayStack.Pop();
            Assert.AreEqual(5, result, "Returned value was not correct.");
        }

        [TestMethod]
        public void ArrayBasedStack_ToArray_FromNonEmptyStack_ShouldReturnCorrectArray()
        {
            var arrayStack = new ArrayStack<int>();
            arrayStack.Push(0);
            arrayStack.Push(1);
            arrayStack.Push(2);
            arrayStack.Push(3);

            var expextedArray = new int[] {3, 2, 1, 0};
            var actualArray = arrayStack.ToArray();
            
            CollectionAssert.AreEqual(expextedArray, actualArray, "Returned array was not correct.");
        }

        [TestMethod]
        public void ArrayBasedStack_ToArray_FromEmptyStack_ShouldReturnEmptyArray()
        {
            var arrayStack = new ArrayStack<DateTime>();

            var expextedArray = new DateTime[] {};
            var actualArray = arrayStack.ToArray();

            CollectionAssert.AreEqual(expextedArray, actualArray, "Returned array was not correct.");
        }
    }
}
