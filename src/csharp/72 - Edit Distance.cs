namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{MinDistance("", "")}");
        Console.WriteLine($"{MinDistance("horse", "ros")}");
        Console.WriteLine($"{MinDistance("intention", "execution")}");
        Console.WriteLine($"{MinDistance("zoologicoarchaeologist", "zoogeologist")}");
    }

    public static int MinDistance(string word1, string word2)
    {
        var dp = new int[word1.Length + 1, word2.Length + 1];

        dp[0, 0] = 0;
        for (int l1 = 1; l1 <= word1.Length; l1++)
        {
            dp[l1, 0] = l1;
        }
        for (int l2 = 1; l2 <= word2.Length; l2++)
        {
            dp[0, l2] = l2;
        }

        for (int l1 = 1; l1 <= word1.Length; l1++)
        {
            for (int l2 = 1; l2 <= word2.Length; l2++)
            {
                if (word1[l1 - 1] == word2[l2 - 1])
                {
                    dp[l1, l2] = dp[l1 - 1, l2 - 1];
                }
                else
                {
                    dp[l1, l2] = Math.Min(Math.Min(dp[l1 - 1, l2], dp[l1, l2 - 1]), dp[l1 - 1, l2 - 1]) + 1;
                }
            }
        }
        return dp[word1.Length, word2.Length];
    }

}
