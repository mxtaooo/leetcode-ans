
class Solution
{
    public static void Main(string[] args)
    {
        var solution = new Solution();

        Console.WriteLine($"{solution.Trap(new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 4, 2, 0, 3, 2, 5 })}");

        Console.WriteLine($"{solution.Trap(new int[] { 0, 0, 0, 0, 0 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 0, 1, 1, 1, 0 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 9, 0, 0, 0, 9 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 8, 0, 0, 0, 9 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 9, 0, 0, 0, 8 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 9, 0, 10, 0, 8 })}");

        Console.WriteLine($"{solution.Trap(new int[] { 8, 0, 9, 0, 10, 0, 8, 0, 9 })}");
        Console.WriteLine($"{solution.Trap(new int[] { 8, 0, 9, 0, 10, 0, 9, 0, 8 })}");


    }

    public int Trap(int[] height)
    {
        var (top, index) = (0, 0);
        for (int i = 0; i < height.Length; i++)
        {
            if (height[i] > top)
            {
                (top, index) = (height[i], i);
            }
        }
        
        // the max value is 0, just return 0.
        if (top == 0)
        {
            return 0;
        }

        var sum = 0;

        // left to top
        for (int i = 0; i < index;)
        {
            for (var left = height[i]; height[i] <= left && i < index; i++)
            {
                sum += left - height[i];
            }
        }

        // right to top
        for (int i = height.Length - 1; i > index;)
        {
            for (var right = height[i]; height[i] <= right && i > index; i--)
            {
                sum += right - height[i];
            }
        }

        return sum;
    }

}