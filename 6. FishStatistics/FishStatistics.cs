using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class FishStatistics
{
    static void Main()
    {
        var input = Console.ReadLine();

        var pattern = @"(>*)<\(+('|-|x)>";

        var matchedFishes = Regex.Matches(input, pattern);

        var count = 1;

        foreach (Match fish in matchedFishes)
        {            

            var tailLength = fish.Groups[1].Length;
            var bodyLength = fish.Value.Where(m => m == '(').Count();
            var status = fish.Groups[2].Value;

            
            Console.WriteLine($"Fish {count}: {fish.Value}");

            if (tailLength > 5)
            {
                Console.WriteLine($"  Tail type: Long ({tailLength * 2} cm)");
            }
            else if (tailLength > 1)
            {
                Console.WriteLine($"  Tail type: Medium ({tailLength * 2} cm)");
            }
            else if (tailLength == 1)
            {
                Console.WriteLine($"  Tail type: Short ({tailLength * 2} cm)");
            }
            else if (tailLength == 0)
            {
                Console.WriteLine($"  Tail type: None");
            }

            if (bodyLength > 10)
            {
                Console.WriteLine($"  Body type: Long ({bodyLength * 2} cm)");
            }
            else if (bodyLength > 5)
            {
                Console.WriteLine($"  Body type: Medium ({bodyLength * 2} cm)");
            }
            else
            {
                Console.WriteLine($"  Body type: Short ({bodyLength * 2} cm)");
            }            
           
            if (status == "'")
            {
                Console.WriteLine($"  Status: Awake");
            }
            else if (status == "-")
            {
                Console.WriteLine($"  Status: Asleep");
            }
            else if (status == "x")
            {
                Console.WriteLine($"  Status: Dead");
            }

            count++;
        }

        if (matchedFishes.Count == 0)
        {
            Console.WriteLine("No fish found.");
        }
        
    }
}

