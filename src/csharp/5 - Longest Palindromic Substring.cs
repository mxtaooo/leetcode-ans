class Solution
{
    public string LongestPalindrome(string s)
    {
        var span = ReadOnlySpan<char>.Empty;
        for (int i = 0; i < s.Length; i++)
        {
            var len = 0;
            for (; i-len >= 0 && i+len < s.Length && s[i-len] == s[i+len]; len++) { }
            len--;
            if (len*2+1 > span.Length)
            {
                span = s.AsSpan(i-len, len*2+1);
            }
            if (i+1 < s.Length && s[i] == s[i+1])
            {
                for (len = 0; i-len >= 0 && i+1+len < s.Length && s[i-len] == s[i+1+len]; len++) { }
                len --;
                if (len*2+2 > span.Length)
                {
                    span = s.AsSpan(i-len, len*2+2);
                }
            }
        }
        return new string(span);
    }
}