class Solution
{
    static string LongestCommonPrefix(string[] strs)
    {
        static int CompareSpan(ReadOnlySpan<char> span1, ReadOnlySpan<char> span2)
        {
            var index = 0;
            for (; index < span1.Length && index < span2.Length && span1[index] == span2[index]; index ++) {}
            return index;   // index is length of common prefix
        }

        if (strs.Length == 0) return String.Empty;

        var span = strs[0].AsSpan();
        for (int i = 1; i < strs.Length; i++)
        {
            var len = CompareSpan(span, strs[i]);
            if (len == 0)
            {
                return String.Empty;
            }
            else
            {
                span = span.Slice(0, len);
            }
        }
        return new string(span);
    }
}