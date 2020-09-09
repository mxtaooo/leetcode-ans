class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var (longer, shorter) = nums1.Length > nums2.Length ? (nums1, nums2) : (nums2, nums1);
        var (m, n) = (shorter.Length, longer.Length);

    }
}