namespace P01.ProductsInPriceRange
{
    using System;
    using System.IO;
    using Wintellect.PowerCollections;

    public class ProductsInRange
    {
        static void Main()
        {
            const string productsFilePath = "../../products.txt";
            var products = ReadProductsFromFile(productsFilePath);

            var range = Console.ReadLine();
            var tokens = range.Split(' ');
            var start = decimal.Parse(tokens[0].Trim());
            var end = decimal.Parse(tokens[1].Trim());

            var productsInRange = products.Range(start, true, end, true);

            Console.WriteLine("Product entries: {0}", products.Values.Count);
            WriteProducts(productsInRange);
        }

        private static void WriteProducts(OrderedMultiDictionary<decimal, string>.View productsInRange)
        {
            const int searchNumber = 10000;
            var count = 0;
            foreach (var price in productsInRange)
            {
                foreach (var product in price.Value)
                {
                    Console.WriteLine("{0} {1}", price.Key, product);
                    count++;
                    if (count >= searchNumber)
                    {
                        break;
                    }
                }
                if (count >= searchNumber)
                {
                    break;
                }
            }
        }

        private static OrderedMultiDictionary<decimal, string> ReadProductsFromFile(string productsFilePath)
        {
            var products = new OrderedMultiDictionary<decimal, string>(true);
            using (var reader = new StreamReader(productsFilePath))
            {
                string productEntry = reader.ReadLine();

                while (!string.IsNullOrEmpty(productEntry))
                {
                    var tokens = productEntry.Split(' ');
                    var productName = tokens[0].Trim();
                    var productPrice = decimal.Parse(tokens[1].Trim());
                    products.Add(productPrice, productName);

                    productEntry = reader.ReadLine();
                }
            }

            return products;
        }
    }
}
