using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.CollectionOfProducts
{
    public interface IProductCollection
    {
        void Add(string id, string title, string supplier, decimal price);
        bool Remove(string id);
        IEnumerable<Product> FindProductsInPriceRange(decimal start, decimal end);
        IEnumerable<Product> FindProductsByTitle(string title);
        IEnumerable<Product> FindProductsByTitle(string title, decimal price);
        IEnumerable<Product> FindProductsByTitle(string title, decimal start, decimal end);
        IEnumerable<Product> FindProductsBySupplier(string supplier, decimal price);
        IEnumerable<Product> FindProductsBySupplier(string supplier, decimal start, decimal end);
    }
}
