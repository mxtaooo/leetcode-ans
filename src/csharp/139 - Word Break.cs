using System.Collections;

namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{WordBreak("l", new List<string> { "l", "code" })}");
        Console.WriteLine($"{WordBreak("l", new List<string> { "code" })}");
        Console.WriteLine($"{WordBreak("l", new List<string> { "l" })}");
        Console.WriteLine($"{WordBreak("leetcode", new List<string> { "leet", "code" })}");
        Console.WriteLine($"{WordBreak("applepenapple", new List<string> { "apple", "pen" })}");
        Console.WriteLine($"{WordBreak("catsandog", new List<string> { "cats", "dog", "sand", "and", "cat" })}");
    }

    public static bool WordBreak(string s, IList<string> wordDict)
    {
        var dp = new BitArray(s.Length);
        var set = new HashSet<string>(wordDict);

        for (int i = 0; i < s.Length; i++)
        {
            if (set.Contains(s[..(i + 1)]))
            {
                dp[i] = true;
                continue;
            }
            for (int j = 0; j < i; j++)
            {
                if (dp[j] && set.Contains(s[(j + 1)..(i + 1)]))
                {
                    dp[i] = true;
                    continue;
                }
            }
        }

        return dp[^1];
    }
}