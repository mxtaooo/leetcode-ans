
class Solution
{
    public static void Main(string[] args)
    {
        var solution = new Solution();

        solution.Merge(new int[]{1,2,3,0,0,0}, 3, new int[]{2,5,6}, 3);
        solution.Merge(new int[]{1}, 1, new int[]{}, 0);
        solution.Merge(new int[]{0}, 0, new int[]{1}, 1);

    }

    public void Merge(int[] nums1, int m, int[] nums2, int n)
    {
        Console.WriteLine("========================================");
        Console.WriteLine($"input: nums1=[{string.Join(',', nums1)}] m={m} nums2=[{string.Join(',', nums2)}] n={n}");
        Impl(nums1, m, nums2, n);
        Console.WriteLine($"result: nums=[{string.Join(',', nums1)}]");
        Console.WriteLine("========================================");
    }

    private void Impl(int[] nums1, int m, int[] nums2, int n)
    {
        int i = m-1;
        int j = n-1;

        int k = m + n - 1;

        while (i >= 0 && j >= 0)
        {
            if (nums1[i] > nums2[j])
            {
                nums1[k] = nums1[i];
                i--;
            }
            else
            {
                nums1[k] = nums2[j];
                j--;
            }
            k--;
        }
        while (j >= 0)
        {
            nums1[k] = nums2[j];
            j--;
            k--;
        }
    }
}
