using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        static int Search(int[] nums, int target)
        {
            if (nums.Length == 1)
            {
                return nums[0] == target ? 0 : -1;
            }

            var (i1, i2) = (0, nums.Length - 1);
            while (i2 - i1 > 1)
            {
                var middle = (i1 + i2) / 2;
                if (nums[middle] > nums[i1])
                {
                    i1 = middle;
                }
                else
                {
                    i2 = middle;
                }
            }

            var (start, end) = nums[0] > target ? (i2, nums.Length - 1) : (0, i1);
            while (start <= end)
            {
                if (nums[start] == target)
                {
                    return start;
                }
                if (start + 1 == end)
                {
                    break;
                }
                var middle = (start + end) / 2;
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

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)}");

            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)}");
            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1)}");

            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6)}");
            Console.WriteLine($"{Search(new int[] { 1 }, 6)}");

            // [1,3], 0
        }
    }
}
