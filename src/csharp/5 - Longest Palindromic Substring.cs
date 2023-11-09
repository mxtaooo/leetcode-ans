class Solution
{
    // 中心扩展法
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

    // 动态规划法
    static string LongestPalindrome(string s)
    {
        var dp = new bool[s.Length, s.Length];

        for (int i = 0; i < s.Length; i++)
        {
            dp[i, i] = true;
            for (int l = 0; l <= Math.Min(i, s.Length-1-i) - 1; l++)
            {
                dp[i-l-1, i+l+1] = dp[i-l, i+l] && s[i-l-1] == s[i+l+1];
            }
            if (i+1 < s.Length && s[i] == s[i+1])
            {
                dp[i, i+1] = true;
                for (int l = 0; l < Math.Min(i, s.Length-1-(i+1)); l++)
                {
                    dp[i-l-1, i+1+l+1] = dp[i-l, i+1+l] && s[i-l-1] == s[i+1+l+1];
                }
            }
        }

        var (start, len) = (0, 0);
        for (int i = 0; i < s.Length; i++)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (dp[i, j] && j - i + 1 > len)
                {
                    start = i;
                    len = j - i + 1;
                }
            }
        }

        return s.Substring(start, len);
    }

    // 动态规划 - 2023-11-09新增
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }

        var dp = new bool[s.Length, s.Length];
        var maxLen = 1;
        var maxStart = 0;

        for (int l = 1; l <= s.Length; l++)
        {
            for (int i = 0; i < s.Length - l + 1; i++)
            {
                var j = i + l - 1;
                if (s[i] == s[j] && (i + 1 > j - 1 || dp[i + 1, j - 1]))
                {
                    dp[i, j] = true;
                    if (l > maxLen)
                    {
                        maxLen = l;
                        maxStart = i;
                    }
                }
            }
        }

        return s.Substring(maxStart, maxLen);
    }

    // 动态规划 - 2023-11-09新增
    public string LongestPalindrome(string s) {
        if (string.IsNullOrEmpty(s))
        {
            return string.Empty;
        }

        var dp = new BitArray(s.Length * s.Length);
        var maxLen = 1;
        var maxStart = 0;

        for (int l = 1; l <= s.Length; l++)
        {
            for (int i = 0; i < s.Length - l + 1; i++)
            {
                var j = i + l - 1;
                if (s[i] == s[j] && (i + 1 > j - 1 || dp[(i + 1) * s.Length + j - 1]))
                {
                    dp[i * s.Length + j] = true;
                    if (l > maxLen)
                    {
                        maxLen = l;
                        maxStart = i;
                    }
                }
            }
        }

        return s.Substring(maxStart, maxLen);
    }

    static void Main(string[] args)
    {
        Console.WriteLine($"abcba: {LongestPalindrome("abcba")}");
        Console.WriteLine($"babad: {LongestPalindrome("babad")}");
        Console.WriteLine($"cbbd: {LongestPalindrome("cbbd")}");
        Console.WriteLine($": {LongestPalindrome("")}");
        Console.WriteLine($"a: {LongestPalindrome("a")}");
    }
}