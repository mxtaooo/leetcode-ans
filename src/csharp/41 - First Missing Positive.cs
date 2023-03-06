
class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{FirstMissingPositive(new int[] { 2, 3, 4, 1 })}");
        Console.WriteLine($"{FirstMissingPositive(new int[] { 1, 2, 0 })}");
        Console.WriteLine($"{FirstMissingPositive(new int[] { 3, 4, -1, 1 })}");
        Console.WriteLine($"{FirstMissingPositive(new int[] { 3, 4, -1, -1 })}");
        Console.WriteLine($"{FirstMissingPositive(new int[] { 3, 4, 1, 1 })}");
        Console.WriteLine($"{FirstMissingPositive(new int[] { 7, 8, 9, 10, 11 })}");

    }

    public static int FirstMissingPositive(int[] nums)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            while (nums[i] > 0 && nums[i] <= nums.Length && nums[i] != nums[nums[i] - 1])
            {
                (nums[i], nums[nums[i] - 1]) = (nums[nums[i] - 1], nums[i]);
            }
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] != i + 1)
            {
                return i + 1;
            }
        }
        return nums.Length + 1;
    }
}