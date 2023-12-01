
namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{MaxProfit(2, [3, 3, 5, 0, 0, 3, 1, 4])}");
        Console.WriteLine($"{MaxProfit(2, [1, 2, 3, 4, 5])}");
        Console.WriteLine($"{MaxProfit(2, [7, 6, 4, 3, 1])}");
        Console.WriteLine($"{MaxProfit(2, [2, 4, 1])}");
        Console.WriteLine($"{MaxProfit(2, [3, 2, 6, 5, 0, 3])}");
    }

    public static int MaxProfit(int[] prices)
    {
        return MaxProfit(2, prices);
    }

    public static int MaxProfit(int k, int[] prices)
    {
        var days = prices.Length;
        var trades = k <= days / 2 ? k : days / 2;

        var dp = new int[days, trades + 1, 2];

        for (int d = 0; d < days; d++)
        {
            dp[d, 0, 0] = 0;
            dp[d, 0, 1] = int.MinValue;
        }

        for (int d = 0; d < days; d++)
        {
            for (int t = 1; t <= trades; t++)
            {
                if (d - 1 == -1)
                {
                    dp[d, t, 0] = 0;
                    dp[d, t, 1] = -prices[d];
                    continue;
                }
                dp[d, t, 0] = Math.Max(dp[d - 1, t, 0], dp[d - 1, t, 1] + prices[d]);
                dp[d, t, 1] = Math.Max(dp[d - 1, t, 1], dp[d - 1, t - 1, 0] - prices[d]);
            }
        }

        return dp[days - 1, trades, 0];
    }
}
