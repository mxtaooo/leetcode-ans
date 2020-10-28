class Solution
{

    // K-Sum递归版本
    static IList<IList<int>> KSum(int[] nums, int target, int k, int start)
    {
        var result = new List<IList<int>>();
        if (k == 2)
        {
            var dict = new Dictionary<int, int>();
            var tuples = new HashSet<(int, int)>();
            for (int i = start; i < nums.Length; i++)
            {
                if (dict.ContainsKey(target - nums[i]))
                {
                    tuples.Add((nums[i], nums[dict[target-nums[i]]]));
                }
                dict[nums[i]] = i;
            }
            foreach (var (n1, n2) in tuples)
            {
                result.Add(new List<int>() {n1, n2});
            }
        }
        else
        {
            for (int i = start; i < nums.Length; )
            {
                foreach (var item in KSum(nums, target-nums[i], k-1, i+1))
                {
                    item.Add(nums[i]);
                    result.Add(item);
                }
                do
                {
                    i++;
                } while (i < nums.Length && nums[i] == nums[i-1]);
            }
        }
        return result;
    }
    static IList<IList<int>> FourSum2(int[] nums, int target)
    {
        Array.Sort(nums);
        return KSum(nums, target, 4, 0);
    }

    // 双指针版本
    static IList<IList<int>> FourSum(int[] nums, int target)
    {
        void PreNumber(ref int index)
        {
            do
            {
                index--;
            } while(index >= 0 && nums[index] == nums[index+1]);
        }
        
        void NextNumber(ref int index)
        {
            do
            {
                index++;
            } while(index < nums.Length && nums[index] == nums[index-1]);
        }
        var result = new List<IList<int>>();
        Array.Sort(nums);
        for (int i = 0; i < nums.Length; NextNumber(ref i))
        {
            for (int j = i+1; j < nums.Length; NextNumber(ref j))
            {
                for (var (m, n) = (j+1, nums.Length-1); m < n; )
                {
                    var sum = nums[i] + nums[j] + nums[m] + nums[n];
                    if (sum > target)
                    {
                        PreNumber(ref n);
                    } else if (sum < target)
                    {
                        NextNumber(ref m);
                    }
                    else
                    {
                        result.Add(new List<int>() {nums[i], nums[j], nums[m], nums[n]});
                        NextNumber(ref m);
                        PreNumber(ref n);
                    }
                }
            }
        }
        return result;
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"[{String.Join(',', FourSum(new int[] {1, 0, -1, 0, -2, 2}, 0).Select(l => $"[{String.Join(',', l)}]"))}]");
        Console.WriteLine($"[{String.Join(',', FourSum(new int[] {}, 0).Select(l => $"[{String.Join(',', l)}]"))}]");
        Console.WriteLine($"[{String.Join(',', FourSum2(new int[] {1, 0, -1, 0, -2, 2}, 0).Select(l => $"[{String.Join(',', l)}]"))}]");
        Console.WriteLine($"[{String.Join(',', FourSum2(new int[] {}, 0).Select(l => $"[{String.Join(',', l)}]"))}]");
    }
}