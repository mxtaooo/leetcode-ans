class Solution
{
    // correct solution
    static IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        if (nums.Length <= 2) return result;

        Array.Sort(nums);
        // 循环的mutation采用do-while操作是为了确保跳过重复数字
        for (var i = 0; i < nums.Length-2; )
        {
            for (var j = i+1; j < nums.Length-1; )
            {
                var target = 0 - nums[i] - nums[j];
                var index = Array.BinarySearch(nums, j+1, nums.Length-1-j, target);
                if (index > 0)
                {
                    result.Add(new List<int>() {nums[i], nums[j], nums[index]});
                }
                do
                {
                    j++;
                } while (j < nums.Length-1 && nums[j-1] == nums[j]);
            }

            do
            {
                i++;
            } while (i < nums.Length - 2 && nums[i-1] == nums[i]);
        }
        return result;
    }

    // O(N^2) Solution
    static IList<IList<int>> ThreeSum(int[] nums)
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

        var result = new List<IList<int>>();
        if (nums.Length <= 2) return result;

        Array.Sort(nums);
        for (var i = 0; i < nums.Length-2; NextNumber(ref i))
        {
            for (var (j, k) = (i+1, nums.Length-1); j < k; )
            {
                var sum = nums[i] + nums[j] + nums[k];
                if (sum > 0)
                {
                    PreNumber(ref k);
                }
                else if (sum < 0)
                {
                    NextNumber(ref j);
                }
                else
                {
                    result.Add(new List<int>() {nums[i], nums[j], nums[k]});
                    NextNumber(ref j);
                    PreNumber(ref k);
                }
            }
        }
        return result;
    }

    static void Main(string[] args)
    {
        var res1 = ThreeSum(new int[]{-1,0,1,2,-1,-4});
        Console.WriteLine(res1);

        var res2 = ThreeSum(new int[]{});
        Console.WriteLine(res2);

        var res3 = ThreeSum(new int[]{0});
        Console.WriteLine(res3);
    }
}