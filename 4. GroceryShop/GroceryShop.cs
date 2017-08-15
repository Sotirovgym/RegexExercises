using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        var productPattern = @"^([A-Z][a-z]+):(\d+\.?\d{2}?)$";
        var regex = new Regex(productPattern);

        var products = new Dictionary<string, decimal>();

        var input = Console.ReadLine();

        while (input != "bill")
        {
            var productInfo = Regex.Match(input, productPattern);

            if (productInfo.Success)
            {
                var productName = productInfo.Groups[1].Value;
                var productPrice = decimal.Parse(productInfo.Groups[2].Value);
                
                products[productName] = productPrice;
            }

            input = Console.ReadLine();
        }

        foreach (var product in products.OrderByDescending(p => p.Value))
        {
            Console.WriteLine($"{product.Key} costs {product.Value:f2}");
        }
    }
}

