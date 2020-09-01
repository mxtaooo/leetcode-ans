class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        return V2(nums, target);
    }

    private int[] V1(int[] nums, int target)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i + 1; j < nums.Length; j++)
            {
                if (nums[i] + nums[j] == target)
                {
                    return new int[] { i, j };
                }
            }
        }
        throw new ArgumentException("no solution");
    }

    private int[] V2(int[] nums, int target)
    {
        var dict = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (dict.ContainsKey(target - nums[i]))
            {
                return new int[] { i, dict[target - nums[i]] };
            }
            // Add方法对于重复KEY会抛出异常
            dict.TryAdd(nums[i], i);
        }
        throw new ArgumentException("no solution");
    }


    private static void Print(int[] nums, int target)
    {
        var s = new Solution();
        var res = s.TwoSum(nums, target);
        Console.WriteLine($"[{res[0]}, {res[1]}]");
    }

    static void Main()
    {
        Print(new int[] { 2, 7, 11, 15 }, 9);
        Print(new int[] { 3, 2, 4 }, 6);
        Print(new int[] { 3, 3 }, 6);
    }
}