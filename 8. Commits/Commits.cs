using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Commits
{
    static void Main()
    {
        var input = Console.ReadLine();

        var pattern = @"^https:\/\/github.com\/(?<user>[A-Za-z0-9-]*)\/(?<repo>[A-Za-z-_]+)\/commit\/(?<hash>[a-fA-F0-9]{40}),(?<message>[^\n]+),(?<additions>[0-9]+),(?<deletions>[0-9]+)$";

        var result = new Dictionary<string, Dictionary<string, List<Commit>>>();

        while (input != "git push")
        {
            var commits = string.Empty;
            var matchedUrl = Regex.Match(input, pattern);

            if (matchedUrl.Success)
            {
                var user = matchedUrl.Groups["user"].Value;
                var repo = matchedUrl.Groups["repo"].Value;
                var hash = matchedUrl.Groups["hash"].Value;
                var message = matchedUrl.Groups["message"].Value;
                var additions = int.Parse(matchedUrl.Groups["additions"].Value);
                var deletions = int.Parse(matchedUrl.Groups["deletions"].Value);

                var newCommit = new Commit
                {
                    Hash = hash,
                    Message = message,
                    Additions = additions,
                    Deletions = deletions
                };

                if (!result.ContainsKey(user))
                {
                    result[user] = new Dictionary<string, List<Commit>>();
                }

                if (!result[user].ContainsKey(repo))
                {
                    result[user][repo] = new List<Commit>();
                }

                result[user][repo].Add(newCommit);
            }            

            input = Console.ReadLine();
        }

        var sortedUsers = result
            .OrderBy(x => x.Key)
            .ToDictionary(x => x.Key, x => x.Value);

        foreach (var userData in sortedUsers)
        {
            var userName = userData.Key;
            var repos = userData.Value.OrderBy(x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            
            Console.WriteLine($"{userName}:");
            

            foreach (var repo in repos)
            {
                var totalAdditions = repo.Value.Sum(x => x.Additions);
                var totalDeletions = repo.Value.Sum(x => x.Deletions);

                Console.WriteLine($"  {repo.Key}:");
                var commits = repo.Value;
                
                var spaces = "  ";
                var spacesTotal = "";

                foreach (var commit in commits)
                {
                    Console.WriteLine($"{spaces}commit {commit.Hash}: {commit.Message} ({commit.Additions} additions, {commit.Deletions} deletions)");
                    spaces += "  ";
                    spacesTotal += "  ";
                }
                Console.WriteLine($"{spacesTotal}Total: {totalAdditions} additions, {totalDeletions} deletions");
            }
            
        }
    }
}

class Commit
{
    public string Hash { get; set; }

    public string Message { get; set; }

    public int Additions { get; set; }

    public int Deletions { get; set; }
}

