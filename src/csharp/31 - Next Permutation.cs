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

            // 尝试找到较小数字在前的位置
            var index = nums.Length - 1;
            while(index > 0 && nums[index-1] >= nums[index])
            {
                index--;
            }

            // 说明全体数字都是从大到小排列、这是最大数字
            if (index == 0)
            {
                Array.Reverse(nums);
                return;
            }

            // 找到比这个“较小数字”大“一点点”的数字、交换两者位置、并将后半段重排
            var mi = index;
            for (int i = index; i < nums.Length; i++)
            {
                if (nums[i] > nums[index-1] && nums[i] <= nums[mi])
                {
                    mi = i;
                }
            }
            var tmp = nums[mi];
            nums[mi] = nums[index-1];
            nums[index-1] = tmp;
            Array.Reverse(nums, index, nums.Length - index);
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
