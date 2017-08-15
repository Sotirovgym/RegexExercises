using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class BoomingCannon
{
    static void Main()
    {
        var cannonData = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

        var shotDistance = cannonData[0];
        var destroyedElements = cannonData[1];

        var inputString = Console.ReadLine();

        var targetPattern = @"(?<=\\<<<)\w+";

        var matched = Regex.Matches(inputString, targetPattern);
        var listOfMatches = matched.Cast<Match>().Select(m => m.Value).ToList();
        var destroyedTargets = new List<string>();

        var result = new List<string>();

        foreach (var match in listOfMatches)
        {
            var currentMatch = new string(match.Skip(shotDistance).Take(destroyedElements).ToArray());

            if (currentMatch != "")
            {
                result.Add(currentMatch);
            }
        }

        if (result.Count != 0)
        {
            Console.WriteLine(string.Join(@"/\", result));
        }
        
    }
}

