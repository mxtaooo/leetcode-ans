class Solution
{
    // 暴力穷举法
    static int MaxArea(int[] height)
    {
        var max = 0;
        for (int i = 0; i < height.Length; i++)
        {
            for (int j = 1; j < height.Length; j++)
            {
                max = Math.Max(max, Math.Min(height[i], height[j]) * (j - i));
            }
        }
        return max;
    }
    // 两游标内移法
    static int MaxArea(int[] height)
    {
        var max = 0;
        for (var (i, j) = (0, height.Length - 1); i < j; )
        {
            max = Math.Max(max, Math.Min(height[i], height[j]) * (j - i));
            if (height[i] > height[j]) j--;
            else i++;
        }
        return max;
    }
    static void Main(string[] args)
    {
        Console.WriteLine(MaxArea(new int[] {1,8,6,2,5,4,8,3,7}));
        Console.WriteLine(MaxArea(new int[] {1, 1}));
        Console.WriteLine(MaxArea(new int[] {4,3,2,1,4}));
        Console.WriteLine(MaxArea(new int[] {1,2,1}));
    }
}