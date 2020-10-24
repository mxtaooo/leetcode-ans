class Solution
{

    static int ThreeSumClosest(int[] nums, int target)
    {
        // Array.Sort(nums);
        var result = nums[0] + nums[1] + nums[2];
        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = i+1; j < nums.Length; j++)
            {
                for (int k = j+1; k < nums.Length; k++)
                {
                    var cur = nums[i] + nums[j] + nums[k];
                    if (Math.Abs(target - cur) < Math.Abs(target - result))
                    {
                        result = cur;
                    }
                }
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine($"{ThreeSumClosest(new int[] {-1,2,1,-4}, 1)}");
    }
}