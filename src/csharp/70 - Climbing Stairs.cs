class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"n={1};r={ClimbStairs(1)}");
        Console.WriteLine($"n={2};r={ClimbStairs(2)}");
        Console.WriteLine($"n={3};r={ClimbStairs(3)}");
        Console.WriteLine($"n={4};r={ClimbStairs(4)}");
        Console.WriteLine($"n={5};r={ClimbStairs(5)}");

        Console.WriteLine($"n={45};r={ClimbStairs(45)}");
    }
    public static int ClimbStairs(int n)
    {
        return Impl2(n);
    }

    public static int Impl1(int n)
    {
        if (n == 1)
        {
            return 1;
        }
        var dp = new int[n + 1];
        dp[1] = 1;
        dp[2] = 2;
        for (int i = 3; i <= n; i++)
        {
            dp[i] = dp[i - 2] + dp[i - 1];
        }
        return dp[n];
    }

    public static int Impl2(int n)
    {
        if (n == 1)
        {
            return 1;
        }

        var x = 1;
        var y = 2;
        for (int i = 3; i <= n; i++)
        {
            var t = x + y;
            x = y;
            y = t;
        }
        return y;
    }

}
