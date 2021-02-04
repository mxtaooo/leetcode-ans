using System;

namespace CSharpConsoleApp
{
    class Program
    {
        static int Search(int[] nums, int target)
        {
            var (start, end) = (0, nums.Length - 1);
            while (start < end)
            {
                if (nums[start] == target)
                {
                    return start;
                }
                if (nums[end] == target)
                {
                    return end;
                }
                var middle = (start + end) / 2;
                switch (nums[middle])
                {
                    case var x when x == target:
                        return middle;
                    case var x when x < target:
                        start = middle + 1;
                        break;
                    default:
                        end = middle - 1;
                        break;
                }
            }

            return nums[start] > target ? start : (start + 1);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 0));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 1));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 2));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 3));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 4));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 5));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 6));
            Console.WriteLine(Search(new int[] { 1, 3, 5, 6 }, 7));
            Console.WriteLine(Search(new int[] { 1 }, 0));

        }
    }
}
