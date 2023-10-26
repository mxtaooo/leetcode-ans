namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{Slove(new int[] { })}");
        Console.WriteLine($"{Slove(new int[] { 1 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 2 })}");
        Console.WriteLine($"{Slove(new int[] { 2, 1 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 5, 2 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 5, 0, 5 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 5, 0, 5 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 5, 0, 5, 10 })}");
        Console.WriteLine($"{Slove(new int[] { 1, 2, 3, 1 })}");
        Console.WriteLine($"{Slove(new int[] { 2, 7, 9, 3, 1 })}");
    }

    public static int Slove(int[] nums)
    {
        return Impl2(nums);
    }

    private static int Impl1(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        if (nums.Length == 1)
        {
            return nums[0];
        }

        // dp[n]表示截至到给定数组第N位的最大收益。
        // 该收益有两种来源(在下面两者中取最大值)：
        // 1. 第N-2位的最大收益及第N位的收益(dp[n-2]+arr[n])
        // 2. 第N-1位的最大收益(dp[n-1])
        var dp = new int[nums.Length];
        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        for (int i = 2; i < nums.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 2] + nums[i], dp[i - 1]);
        }
        return dp[^1];
    }

    private static int Impl2(int[] nums)
    {
        if (nums.Length == 0)
        {
            return 0;
        }
        if (nums.Length == 1)
        {
            return nums[0];
        }
        if (nums.Length == 2)
        {
            return Math.Max(nums[0], nums[1]);
        }

        // 定义xyz分别表示第N-2、N-1、N位的最大收益
        var x = nums[0];
        var y = Math.Max(nums[0], nums[1]);
        var z = Math.Max(nums[0] + nums[2], nums[1]);
        for (int i = 3; i < nums.Length; i++)
        {
            x = y;
            y = z;
            z = Math.Max(x + nums[i], y);
        }
        return z;
    }

}
