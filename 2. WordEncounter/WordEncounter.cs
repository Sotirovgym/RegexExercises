using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class WordEncounter
{
    static void Main()
    {
        var filter = Console.ReadLine();
        var filterLetter = filter[0];
        var filterCount = int.Parse(filter[1].ToString());

        var input = Console.ReadLine();

        var words = new List<string>();

        var sentencePattern = @"^[A-Z].*[.!?]$";
        var wordsPattern = @"\w+";

        while (input != "end")
        {

            var sentences = Regex.Matches(input, sentencePattern);

            foreach (Match sentence in sentences)
            {
                var sentenceInWords = Regex.Matches(sentence.ToString(), wordsPattern);

                foreach (var word in sentenceInWords)
                {
                    var count = Regex.Matches($"{word}", $"{filterLetter}").Count;

                    if (count >= filterCount)
                    {
                        words.Add(word.ToString());
                    }
                }
            }

            input = Console.ReadLine();
        }

        Console.WriteLine(string.Join(", ", words));
    }
}

