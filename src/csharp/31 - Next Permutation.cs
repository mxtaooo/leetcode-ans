using System;
using System.Collections.Generic;
using System.Linq;

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
            for (int index = nums.Length - 1; index > 0; index--)
            {
                if (nums[index-1] < nums[index])
                {
                    var tmp = nums[index];
                    nums[index] = nums[index-1];
                    nums[index-1] = tmp;
                    return;
                }
            }
            Array.Sort(nums);
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

            // 132 => 213 但算出312
        }
    }
}
