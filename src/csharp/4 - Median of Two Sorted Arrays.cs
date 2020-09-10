class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        var (longer, shorter) = nums1.Length > nums2.Length ? (nums1, nums2) : (nums2, nums1);
        var (m, n) = (shorter.Length, longer.Length);

        for (var (imin, imax) = (0, m); ; )
        {
            var i = (imin + imax) / 2;
            var j = (m + n) / 2 - i;

            if (i != 0 && shorter[i - 1] > longer[j])
            {
                imax = i - 1;
            }
            else if (i != m && shorter[i] < longer[j - 1])
            {
                imin = i + 1;
            }
            else
            {
                // j = (m+n)/2 -i，多余元素必定在右侧
                // j = (m+n+1)/2 - i，多余元素必定在左侧
                var right = (i, j) switch
                {
                    _ when i == m => longer[j],
                    _ when j == n => shorter[i],
                    _ => Math.Min(shorter[i], longer[j])
                };
                if ((m + n) % 2 == 1)
                {
                    return right;
                }
                var left = (i, j) switch
                {
                    (0, _) => longer[j - 1],
                    (_, 0) => shorter[i - 1],
                    _ => Math.Max(shorter[i - 1], longer[j - 1])
                };
                return (left + right) / 2.0;
            }
        }

    }
}