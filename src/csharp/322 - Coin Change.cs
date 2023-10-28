
namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{CoinChange(new int[] { 1, 2, 5 }, 11)}");
        Console.WriteLine($"{CoinChange(new int[] { 2 }, 3)}");
        Console.WriteLine($"{CoinChange(new int[] { 1 }, 0)}");
    }

    public static int CoinChange(int[] coins, int amount)
    {
        var dp = new int[amount + 1];
        Array.Fill(dp, -1);
        dp[0] = 0;

        for (int n = 1; n <= amount; n++)
        {
            foreach (var coin in coins)
            {
                if (coin == n)
                {
                    dp[n] = 1;
                    break;
                }
                if (n < coin || dp[n - coin] == -1)
                {
                    continue;
                }

                if (dp[n] == -1)
                {
                    dp[n] = dp[n - coin] + 1;
                }
                else
                {
                    dp[n] = Math.Min(dp[n - coin] + 1, dp[n]);
                }
            }
        }
        return dp[amount];
    }
}

