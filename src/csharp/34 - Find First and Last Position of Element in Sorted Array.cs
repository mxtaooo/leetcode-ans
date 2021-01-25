using System;

namespace CSharpConsoleApp
{
    class Program
    {
        static int[] Search(int[] nums, int target)
        {

            int Hit()
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


            var p = Hit();

            if (p == -1)
            {
                return new int[] { -1, -1 };
            }

            var start = 0;
            if (nums[0] != target)
            {
                while (true)
                {
                    if (nums[start-1] < target)
                    {
                        
                    }
                }
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 3)}");

            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 0)}");
            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 1)}");

            Console.WriteLine($"{Search(new int[] { 4, 5, 6, 7, 0, 1, 2 }, 6)}");
            Console.WriteLine($"{Search(new int[] { 1 }, 6)}");
            Console.WriteLine($"{Search(new int[] { 1, 3 }, 6)}");
            Console.WriteLine($"{Search(new int[] { 1, 3 }, 0)}");
            Console.WriteLine($"{Search(new int[] { 3, 1 }, 1)}");
            Console.WriteLine($"{Search(new int[] { 3, 1 }, 3)}");
        }
    }
}
