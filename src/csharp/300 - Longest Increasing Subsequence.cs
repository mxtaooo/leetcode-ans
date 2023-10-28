using System.Collections;

namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{LengthOfLIS(new int[] { 10, 9, 2, 5, 3, 7, 101, 18 })}");
        Console.WriteLine($"{LengthOfLIS(new int[] { 0, 1, 0, 3, 2, 3 })}");
        Console.WriteLine($"{LengthOfLIS(new int[] { 7, 7, 7, 7, 7, 7, 7 })}");
        Console.WriteLine($"{LengthOfLIS(new int[] { 0 })}");

    }

    public static int LengthOfLIS(int[] nums) => Impl1(nums);

    // 常规动态规划
    private static int Impl1(int[] nums)
    {
        var dp = new int[nums.Length];
        Array.Fill(dp, 1);

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = 0; j < i; j++)
            {
                if (nums[i] > nums[j])
                {
                    dp[i] = Math.Max(dp[i], dp[j] + 1);
                }
            }
        }

        return dp.Max();
    }

    // 时间复杂度可以优化到NlogN
    private static int Impl2(int[] nums)
    {
        throw new NotImplementedException("TODO");
    }

}
