class Solution
{

    // 暴力解法
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

    // O(N^2) 双指针解法
    static int ThreeSumClosest(int[] nums, int target)
    {
        // 确保游标移动到下一个数字
        void PreNumber(ref int index)
        {
            do
            {
                index--;
            } while(index >= 0 && nums[index] == nums[index+1]);
        }
        // 确保游标移动到上一个数字
        void NextNumber(ref int index)
        {
            do
            {
                index++;
            } while(index < nums.Length && nums[index] == nums[index-1]);
        }

        Array.Sort(nums);
        var result = nums[0] + nums[1] + nums[2];
        for (var i = 0; i < nums.Length-2; NextNumber(ref i))
        {
            for (var (j, k) = (i+1, nums.Length-1); j < k; )
            {
                var sum = nums[i] + nums[j] + nums[k];
                if (Math.Abs(target-sum) < Math.Abs(target-result))
                {
                    result = sum;
                }
                if (sum > target)
                {
                    PreNumber(ref k);
                }
                else
                {
                    NextNumber(ref j);
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