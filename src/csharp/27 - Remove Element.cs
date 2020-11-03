class Solution
{
    int RemoveElement(int[] nums, int val)
    {
        var (i, j) = (0, nums.Length-1);
        while (i <= j)
        {
            while (i < nums.Length && nums[i] != val)
            {
                i++;
            }
            while (j >= 0 && nums[j] == val)
            {
                j--;
            }
            if (i < j)
            {
                nums[i] = nums[j];
                nums[j] = val;
                i++;
                j--;
            }
        }
        return i;
    }
}
