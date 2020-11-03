class Solution
{
    int RemoveDuplicates(int[] nums)
    {
        if (nums.Length == 0) return 0;
        var p = 0;
        for (int i = 1; i < nums.Length; i++)
        {
            if (nums[i] != nums[p])
            {
                p++;
                nums[p] = nums[i];
            }
        }
        return p+1;
    }
}