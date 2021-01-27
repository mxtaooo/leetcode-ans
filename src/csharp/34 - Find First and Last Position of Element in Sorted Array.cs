using System;

namespace CSharpConsoleApp
{
    class Program
    {
        static int[] SearchRange(int[] nums, int target)
        {
            int BinarySearch()
            {
                if (nums[0] == target)
                {
                    return 0;
                }
                if (nums[^1] == target)
                {
                    return nums.Length - 1;
                }
                var (start, end) = (0, nums.Length - 1);
                while (true)
                {
                    var middle = (start + end) / 2;
                    if (nums[middle] == target)
                    {
                        return middle;
                    }
                    if (start == middle || end == middle)
                    {
                        break;
                    }
                    if (nums[middle] > target)
                    {
                        end = middle;
                    }
                    else
                    {
                        start = middle;
                    }
                }

                return -1;
            }

            var random = nums.Length == 0 ? -1 : BinarySearch();
            if (random == -1)
            {
                return new int[] { -1, -1 };
            }

            var start = 0;
            if (nums[0] != target)
            {
                var (s, e) = (1, random);
                while (!(nums[s-1] != target && nums[s] == target))
                {
                    var m = (s + e) / 2;
                    if (m == s)
                    {
                        s++;
                        break;
                    }
                    if (nums[m] == target)
                    {
                        e = m;
                    }
                    else
                    {
                        s = m;
                    }
                }
                start = s;
            }

            var end = nums.Length - 1;
            if (nums[^1] != target)
            {
                var (s, e) = (random, nums.Length-1);
                while (!(nums[s + 1] != target && nums[s] == target))
                {
                    var m = (s + e) / 2;
                    if (m == s)
                    {
                        s--;
                        break;
                    }
                    if (nums[m] == target)
                    {
                        s = m;
                    }
                    else
                    {
                        e = m;
                    }
                }
                end = s;
            }
            return new int[] { start, end };
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(string.Join(",", SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 8)));
            Console.WriteLine(string.Join(",", SearchRange(new int[] { 5, 7, 7, 8, 8, 10 }, 6)));
            Console.WriteLine(string.Join(",", SearchRange(Array.Empty<int>(), 0)));
        }
    }
}
