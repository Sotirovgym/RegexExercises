using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        // Match happy emoticons
        var happyPattern = @"([;:][)D*\]}]|[(*c[][;:])";
        // Match sad emoticons
        var sadPattern = @"([:;][([{c]|[D\])][;:])";

        var input = Console.ReadLine();

        var happyEmoticons = Regex.Matches(input, happyPattern);
        var sadEmoticons = Regex.Matches(input, sadPattern);

        var happyEmoteCount = happyEmoticons.Count;
        var sadEmoteCount = sadEmoticons.Count;

        var happinessIndex = Math.Round((double)happyEmoteCount / sadEmoteCount, 2);

        if (happinessIndex >= 2)
        {
            Console.WriteLine($"Happiness index: {happinessIndex:f2} :D");
            Console.WriteLine($"[Happy count: {happyEmoteCount}, Sad count: {sadEmoteCount}]");
        }
        else if (happinessIndex > 1)
        {
            Console.WriteLine($"Happiness index: {happinessIndex:f2} :)");
            Console.WriteLine($"[Happy count: {happyEmoteCount}, Sad count: {sadEmoteCount}]");
        }
        else if (happinessIndex == 1)
        {
            Console.WriteLine($"Happiness index: {happinessIndex:f2} :|");
            Console.WriteLine($"[Happy count: {happyEmoteCount}, Sad count: {sadEmoteCount}]");
        }
        else if (happinessIndex < 1)
        {
            Console.WriteLine($"Happiness index: {happinessIndex:f2} :(");
            Console.WriteLine($"[Happy count: {happyEmoteCount}, Sad count: {sadEmoteCount}]");
        }
    }
}

