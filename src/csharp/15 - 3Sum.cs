class Solution
{
    static IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (var (i, j) = (0, nums.Length-1); i < j; )
        {
            var target = 0 - nums[i] - nums[j];
            if (target >= nums[i] && target <= nums[j])
            {
                var index = Array.BinarySearch(nums, i+1, j-i, target);
                if (index > i && index < j)
                {
                    result.Add(new List<int>{nums[i], nums[index], nums[j]});
                    if (j-index < index-i)
                    {
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }
                else
                {
                    if (index == ~(j+1))
                    {
                        i++;
                    }
                    else
                    {
                        j--;
                    }
                }
            }
            else
            {
                if (target > nums[j])
                {
                    i++;
                }
                else
                {
                    j--;
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