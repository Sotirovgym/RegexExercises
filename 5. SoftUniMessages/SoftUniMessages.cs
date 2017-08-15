using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class SoftUniMessages
{
    static void Main()
    {
        

        var pattern = @"^\d+([A-Za-z]+)[^a-zA-Z]+$";        
        var result = new Dictionary<string, string>();

        while (true)
        {
            var input = Console.ReadLine();

            if (input == "Decrypt!")
            {
                break;
            }

            var length = int.Parse(Console.ReadLine());

            var text = Regex.Match(input, pattern);

            var message = text.Groups[1].Value;
            var decodeMessage = string.Empty;

            if (text.Success && message.Length == length)
            {
                var matchedNumbers = Regex.Matches(input, @"\d");
                var indices = matchedNumbers.Cast<Match>().Select(m => int.Parse(m.Value)).ToList();

                for (int i = 0; i < indices.Count; i++)
                {
                    var index = indices[i];

                    if (index < message.Length)
                    {
                        decodeMessage += message[indices[i]];
                    }
                   
                }

                Console.WriteLine($"{message} = {decodeMessage}");
            }
        }
    }
}

