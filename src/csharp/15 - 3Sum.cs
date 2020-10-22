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