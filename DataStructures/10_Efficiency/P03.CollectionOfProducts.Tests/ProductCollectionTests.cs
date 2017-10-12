using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace P03.CollectionOfProducts.Tests
{
    [TestClass]
    public class ProductCollectionTests
    {
        [TestMethod]
        public void Add_SingleProduct_ShouldAdd()
        {
            var products = new ProductCollection();
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void Add_SameProducts_ShouldAddOnlyOne()
        {
            var products = new ProductCollection();
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            Assert.AreEqual(1, products.Count);
        }

        [TestMethod]
        public void Remove_ExistingProduct_ShouldRemove()
        {
            var products = new ProductCollection();
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            bool result = products.Remove(id: "123");

            Assert.AreEqual(true, result);
            Assert.AreEqual(0, products.Count);
        }

        [TestMethod]
        public void Remove_NonExistingProduct_ShouldNotRemove()
        {
            var products = new ProductCollection();
            products.Add(id: "123", title: "abv", supplier: "acme", price: 4.23m);
            bool result = products.Remove(id: "125");

            Assert.AreEqual(false, result);
            Assert.AreEqual(1, products.Count);
        }
    }
}
