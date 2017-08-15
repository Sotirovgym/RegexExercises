using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Cards
{
    static void Main()
    {
        var inputCards = Console.ReadLine();

        var pattern = @"(?<power>\d+|[JQKA]+)(?<suit>[SHDC])";

        var matches = Regex.Matches(inputCards, pattern);
        var result = new List<string>();
        var number = 0;

        foreach (Match match in matches)
        {
            var power = match.Groups["power"].Value;
            var suit = match.Groups["suit"].Value;

            var isParse = int.TryParse(power, out number);

            if (isParse)
            {
                if (number >= 2 && number <= 10)
                {
                    result.Add(match.Groups[0].Value);
                }
            }
            else if (power == "J" || power == "Q" || power == "K" || power == "A")
            {
                result.Add(match.Groups[0].Value);
            }
        }

        Console.WriteLine(string.Join(", ", result));
    }
}

