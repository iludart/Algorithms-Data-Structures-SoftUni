using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using Wintellect.PowerCollections;

public class ShoppingCenterProgram
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        var center = new ShoppingCenter();

        int commandsCount = int.Parse(Console.ReadLine());
        for (int i = 0; i < commandsCount; i++)
        {
            string command = Console.ReadLine();
            string commandResult = center.ProcessCommand(command);
            Console.WriteLine(commandResult);
        }
    }
}

public class ShoppingCenter
{
    private readonly MultiDictionary<string, Product> productsByName = 
        new MultiDictionary<string, Product>(true);

    private readonly MultiDictionary<string, Product> productsByProducer =
        new MultiDictionary<string, Product>(true);

    private readonly MultiDictionary<string, Product> productsByNameAndProducer =
        new MultiDictionary<string, Product>(true);

    private readonly OrderedMultiDictionary<decimal, Product> productsByPrice =
        new OrderedMultiDictionary<decimal, Product>(true);

    public string AddProduct(string name, string price, string producer)
    {
        var product = new Product()
        {
            Name = name,
            Price = decimal.Parse(price),
            Producer = producer,
        };

        // add by name
        this.productsByName[name].Add(product);

        // add by producer
        this.productsByProducer[producer].Add(product);

        // add by name and producer
        var combinedKey = this.CombineNameAndProducer(name, producer);
        this.productsByNameAndProducer[combinedKey].Add(product);

        // add by price
        var priceKey = decimal.Parse(price);
        this.productsByPrice[priceKey].Add(product);

        return "Product added";
    }

    public string DeleteProducts(string producer)
    {
        var count = 0;
        if (this.productsByProducer.ContainsKey(producer))
        {
            var productsFound = this.productsByProducer[producer];
            foreach (var product in productsFound)
            {
                // delete by name
                this.productsByName[product.Name].Remove(product);

                // delete by name and producer
                string nameAndProducer = this.CombineNameAndProducer(product.Name, product.Producer);
                this.productsByNameAndProducer[nameAndProducer].Remove(product);

                // delete by price
                this.productsByPrice[product.Price].Remove(product);

                count++;
            }

            this.productsByProducer.Remove(producer);
            return string.Format("{0} products deleted", count);
        }

        return string.Format("No products found");
    }

    public string DeleteProducts(string name, string producer)
    {
        var count = 0;
        var combinedKey = this.CombineNameAndProducer(name, producer);
        if (this.productsByNameAndProducer.ContainsKey(combinedKey))
        {
            var productsFound = this.productsByNameAndProducer[combinedKey];
            foreach (var product in productsFound)
            {
                // delete by name
                this.productsByName[product.Name].Remove(product);

                // delete by producer
                this.productsByProducer[product.Producer].Remove(product);

                // delete by price
                this.productsByPrice[product.Price].Remove(product);

                count++;
            }

            this.productsByNameAndProducer.Remove(combinedKey);
            return string.Format("{0} products deleted", count);
        }

        return string.Format("No products found");
    }

    public string FindProductsByName(string name)
    {
        var result = "No products found";
        if (productsByName.ContainsKey(name))
        {
            var productsFound = productsByName[name];
            result = this.SortAndPrintProducts(productsFound);
        }

        return result;
    }

    public string FindProductsByProducer(string producer)
    {
        var result = "No products found";
        if (this.productsByProducer.ContainsKey(producer))
        {
            var productsFound = productsByProducer[producer];
            result = this.SortAndPrintProducts(productsFound);
        }

        return result;
    }

    public string FindProductsByPriceRange(string from, string to)
    {
        var fromPrice = decimal.Parse(from);
        var toPrice = decimal.Parse(to);
        var productsFound = this.productsByPrice.Range(fromPrice, true, toPrice, true).Values;

        return this.SortAndPrintProducts(productsFound);
    }

    public string ProcessCommand(string command)
    {
        var separatorIndex = command.IndexOf(' ');
        var method = command.Substring(0, separatorIndex);
        var commandParameters = command.Substring(separatorIndex + 1).Split(';');
        string commandResult = string.Empty;
        switch (method)
        {
            case "AddProduct":
                commandResult = this.AddProduct(commandParameters[0], commandParameters[1], commandParameters[2]);
                return commandResult;
            case "DeleteProducts":
                if (commandParameters.Length == 1)
                {
                    commandResult = this.DeleteProducts(commandParameters[0]);
                }
                else if (commandParameters.Length == 2)
                {
                    commandResult = this.DeleteProducts(commandParameters[0], commandParameters[1]);
                }

                return commandResult;
            case "FindProductsByName":
                commandResult = this.FindProductsByName(commandParameters[0]);
                return commandResult;
            case "FindProductsByProducer":
                commandResult = this.FindProductsByProducer(commandParameters[0]);
                return commandResult;
            case "FindProductsByPriceRange":
                commandResult = this.FindProductsByPriceRange(commandParameters[0], commandParameters[1]);
                return commandResult;
            default:
                return "Unknown command";
        }
    }

    private string SortAndPrintProducts(IEnumerable<Product> products)
    {
        if (products.Any())
        {
            var sortedProducts = products.OrderBy(p => p);
            return string.Join(Environment.NewLine, sortedProducts);
        }

        return "No products found";
    }

    private string CombineNameAndProducer(string name, string producer)
    {
        return name + ";" + producer;
    }
}

public class Product : IComparable<Product>
{
    public string Name { get; set; }

    public decimal Price { get; set; }

    public string Producer { get; set; }

    public int CompareTo(Product other)
    {
        if (other == this)
        {
            return 0;
        }

        var result = this.Name.CompareTo(other.Name);
        if (result == 0)
        {
            result = this.Producer.CompareTo(other.Producer);
        }

        if (result == 0)
        {
            result = this.Price.CompareTo(other.Price);
        }

        return result;
    }

    public override string ToString()
    {
        return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Producer, this.Price);
    }
}
