using System;

namespace CSharpConsoleApp
{
    class Program
    {
        static void NextPermutation(int[] nums)
        {
            if (nums.Length <= 1)
            {
                return;
            }
            var start = 0;
            for (int index = nums.Length - 1; index > 0; index--)
            {
                if (nums[index-1] < nums[index])
                {
                    var (mi, min) = (index, nums[index]);
                    for (int i = index; i < nums.Length; i++)
                    {
                        if (nums[i] > nums[index-1] && nums[i] < min)
                        {
                            mi = i;
                            min = nums[i];
                        }
                    }
                    nums[mi] = nums[index - 1];
                    nums[index - 1] = min;
                    start = index;
                    break;
                }
            }
            Array.Sort(nums, start, nums.Length - start);
            return;
        }

        static void Execute(int[] nums)
        {
            var origin = $"[{string.Join(", ", nums)}]";
            NextPermutation(nums);
            var newer = $"[{string.Join(", ", nums)}]";
            Console.WriteLine($"{origin} => {newer}");
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Execute(new int[] { 1, 2, 3 });
            Execute(new int[] { 3, 2, 1 });
            Execute(new int[] { 1, 1, 5 });
            Execute(new int[] { 1 });
            Execute(new int[] { 1, 3, 2 });
            Execute(new int[] { 1, 3, 3 });
        }
    }
}
