using System;
using System.Collections.Generic;
using DictionaryExtensions;

namespace P03.CollectionOfProducts
{
    public class ProductCollection : IProductCollection
    {
        private IDictionary<string, Product> products;
        private Dictionary<decimal, SortedSet<Product>> productsByPrice;
        private Dictionary<string, SortedSet<Product>> productsByTitle;
        private Dictionary<string, SortedSet<Product>> productsByTitleAndPrice;
        private Dictionary<string, Dictionary<decimal, SortedSet<Product>>> productsByTitleAndPriceRange;
        private Dictionary<string, SortedSet<Product>> productsBySupplierAndPrice;
        private Dictionary<string, Dictionary<decimal, SortedSet<Product>>> productsBySupplierAndPriceRange;

        public ProductCollection()
        {
            this.products = new Dictionary<string, Product>();
            this.productsByPrice = new Dictionary<decimal, SortedSet<Product>>();
            this.productsByTitle = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPrice = new Dictionary<string, SortedSet<Product>>();
            this.productsByTitleAndPriceRange = new Dictionary<string, Dictionary<decimal, SortedSet<Product>>>();
            this.productsBySupplierAndPrice = new Dictionary<string, SortedSet<Product>>();
            this.productsBySupplierAndPriceRange = new Dictionary<string, Dictionary<decimal, SortedSet<Product>>>();
        }

        public int Count { get { return this.products.Count; } }

        public void Add(string id, string title, string supplier, decimal price)
        {
            var product = new Product()
            {
                Id = id,
                Title = title,
                Supplier = supplier,
                Price = price,
            };

            // add prod by id
            this.products.EnsureKeyExists(id);
            this.products[id] = product;

            // add prod by price
            this.productsByPrice.EnsureKeyExists(price);
            this.productsByPrice.AppendValueToKey(price, product);

            // add prod by title

            // add prod by title and price

            // add prod by title and price range

            // add prod by supplier and price

            // add prod by supplier and price range

        }

        public bool Remove(string id)
        {
            bool remove = this.products.ContainsKey(id);

            if (remove)
            {
                var product = this.products[id];

                // remove prod by id
                this.products.Remove(id);

                // remove prod by price
                this.productsByPrice[product.Price].Remove(product);

                // remove prod by title

                // remove prod by title and price

                // remove prod by title and price range

                // remove prod by supplier and price

                // remove prod by supplier and price range

                return remove;
            }

            return remove;
        }

        public IEnumerable<Product> FindProductsInPriceRange(decimal start, decimal end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsByTitle(string title)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsByTitle(string title, decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsByTitle(string title, decimal start, decimal end)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsBySupplier(string supplier, decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Product> FindProductsBySupplier(string supplier, decimal start, decimal end)
        {
            throw new NotImplementedException();
        }
    }
}
