namespace P06.LinkedStack.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using P05.LinkedStack;

    [TestClass]
    public class LinkedStackTests
    {
        [TestClass]
        public class ArrayBasedStackTests
        {
            [TestMethod]
            public void LinkedStack_ParameterlessConstructor_CountShouldBeZeroThenOne()
            {
                var linkedStack = new LinkedStack<int>();

                Assert.AreEqual(0, linkedStack.Count);

                linkedStack.Push(5);

                Assert.AreEqual(1, linkedStack.Count);
            }

            [TestMethod]
            public void LinkedStack_ConstructorWithParameters_CountShouldBeOne()
            {
                var linkedStack = new LinkedStack<int>(5);

                Assert.AreEqual(1, linkedStack.Count, "Constructor does not set initial stack count properly");

                var poppedElement = linkedStack.Pop();

                Assert.AreEqual(5, poppedElement, "Constructor does not pass valid element.");
            }

            [TestMethod]
            public void LinkedStack_Push_1000ElementsToEmptyStack_ShouldAddCorrectly()
            {
                var linkedStack = new LinkedStack<int>();
                for (int i = 1; i <= 1000; i++)
                {
                    linkedStack.Push(i);
                    Assert.AreEqual(i, linkedStack.Count, "Count on push was not correct.");
                }

                for (int i = 1000; i > 0; i--)
                {
                    Assert.AreEqual(i, linkedStack.Count, "Count on pop was not correct.");
                    var poppedElement = linkedStack.Pop();
                    Assert.AreEqual(i, poppedElement, "Popped element was not correct.");
                }
            }

            [TestMethod]
            [ExpectedException(typeof (InvalidOperationException))]
            public void LinkedStack_Pop_OneElementToEmptyStack_ShouldThrow()
            {
                var linkedStack = new LinkedStack<int>();

                linkedStack.Pop();
            }

            [TestMethod]
            public void LinkedStack_Pop_OneElementFromNonEmptyStack_ShouldReturnElement()
            {
                var linkedStack = new LinkedStack<int>();
                linkedStack.Push(5);

                var result = linkedStack.Pop();
                Assert.AreEqual(5, result, "Returned value was not correct.");
            }

            [TestMethod]
            public void LinkedStack_ToArray_FromNonEmptyStack_ShouldReturnCorrectArray()
            {
                var linkedStack = new LinkedStack<int>();
                linkedStack.Push(0);
                linkedStack.Push(1);
                linkedStack.Push(2);
                linkedStack.Push(3);

                var expextedArray = new int[] {3, 2, 1, 0};
                var actualArray = linkedStack.ToArray();

                CollectionAssert.AreEqual(expextedArray, actualArray, "Returned array was not correct.");
            }

            [TestMethod]
            public void LinkedStack_ToArray_FromEmptyStack_ShouldReturnEmptyArray()
            {
                var linkedStack = new LinkedStack<DateTime>();

                var expextedArray = new DateTime[] {};
                var actualArray = linkedStack.ToArray();

                CollectionAssert.AreEqual(expextedArray, actualArray, "Returned array was not correct.");
            }
        }
    }
}
