//namespace P01.Dictionary.Tests
//{
//    using System;
//    using Microsoft.VisualStudio.TestTools.UnitTesting;

//    [TestClass]
//    public class DictionaryTests
//    {
//        [TestMethod]
//        public void Constructor_InitializieWithoutParameters_ShouldHaveCapacity16()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            Assert.AreEqual(16, dictionary.Capacity, "Capacity was not correct.");
//        }

//        [TestMethod]
//        public void Constructor_InitializieWithParameters_ShouldHaveCapacity1000()
//        {
//            var dictionary = new CustomDictionary<int, int>(1000);

//            Assert.AreEqual(1000, dictionary.Capacity, "Capacity was not correct.");
//        }

//        [TestMethod]
//        public void Constructor_InitializieWithoutParameters_CountShouldBe0()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            Assert.AreEqual(0, dictionary.Count, "Count was not correct.");
//        }

//        [TestMethod]
//        public void Add_AddOneElement_ShouldHaveCount1()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary.Add(1, 1);

//            Assert.AreEqual(1, dictionary.Count, "Count was not correct.");
//        }

//        [TestMethod]
//        [ExpectedException(typeof(ArgumentException))]
//        public void Add_TwoSameElement_ShouldThrow()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary.Add(1, 1);
//            dictionary.Add(1, 1);
//        }

//        [TestMethod]
//        public void Grow_GrowOnce_ShouldHaveCapacity4()
//        {
//            var dictionary = new CustomDictionary<int, int>(2);

//            dictionary.Add(1, 1);
//            dictionary.Add(2, 1);

//            Assert.AreEqual(4, dictionary.Capacity, "Count was not correct.");
//        }

//        [TestMethod]
//        public void ContainsKey_ExistingElement_ShouldReturnTrue()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary.Add(1, 1);
//            dictionary.Add(2, 1);

//            Assert.AreEqual(true, dictionary.ContainsKey(1), "Returns false where should return true.");
//            Assert.AreEqual(true, dictionary.ContainsKey(2), "Returns false where should return true.");
//        }

//        [TestMethod]
//        public void Indexer_AddNonExistingElement_ShouldAddCorrectrly()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary[1] = 1;

//            Assert.AreEqual(true, dictionary.ContainsKey(1), "Returns false where should return true.");
//            Assert.AreEqual(1, dictionary.Count, "Count was not correct.");
//            Assert.AreEqual(1, dictionary[1], "Value was not correct.");
//        }

//        [TestMethod]
//        public void Indexer_AddExistingElement_ShouldReplaceCorrectrly()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary[1] = 1;
//            dictionary[1] = 2;

//            Assert.AreEqual(true, dictionary.ContainsKey(1), "Returns false where should return true.");
//            Assert.AreEqual(1, dictionary.Count, "Count was not correct.");
//            Assert.AreEqual(2, dictionary[1], "Value was not correct.");
//        }

//        [TestMethod]
//        public void Remove_ExistingElement_ShouldReturnTrue()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary[1] = 1;

//            Assert.AreEqual(true, dictionary.Remove(1), "Returns false where should return true.");
//            Assert.AreEqual(0, dictionary.Count, "Count was not correct.");
//        }

//        [TestMethod]
//        public void Remove_NonExistingElement_ShouldReturnFalse()
//        {
//            var dictionary = new CustomDictionary<int, int>();

//            dictionary[1] = 1;

//            Assert.AreEqual(false, dictionary.Remove(2), "Returns true where should return false.");
//            Assert.AreEqual(1, dictionary.Count, "Count was not correct.");
//        }
//    }
//}
