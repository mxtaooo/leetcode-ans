class Solution
{
    // 递归解法
    public static bool IsMatch(string s, string p)
    {
        static bool IsMatchOnSpan(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
        {
            if (p.IsEmpty) return s.IsEmpty;

            // 验证两者是否有相同的首字符
            var first = (!s.IsEmpty && (p[0] == s[0] || p[0] == '.'));
            if (p.Length >= 2 && p[1] == '*')
            {
                // 若当前正则首部是*模式、那么有两个尝试方向
                // 一是*模式已匹配完毕、可以尝试正则后面的部分
                // 二是*模式尚未匹配完毕、吞掉已匹配的字符、尝试字符串后面的部分
                return IsMatchOnSpan(s, p.Slice(2)) || (first && IsMatchOnSpan(s.Slice(1), p));
            }
            else
            {
                // 当前正则首部是字符模式、将字符串和正则式同时推进一个字符即可
                return first && IsMatchOnSpan(s.Slice(1), p.Slice(1));
            }
        }
        return IsMatchOnSpan(s.AsSpan(), p.AsSpan());
    }

    // 动态规划解法
    static bool IsMatch(string s, string p)
    {
        bool IsMatch(int si, int pi) => si >= 0 && (p[pi] == '.' || s[si] == p[pi]);

        // dp[i, j]表示字符串s的前i是否与正则p的前j匹配
        var dp = new bool[s.Length + 1, p.Length + 1];
        dp[0, 0] = true;

        for (int sl = 0; sl <= s.Length; sl++)
        {
            for (int pl = 1; pl <= p.Length; pl++)
            {
                if (p[pl-1] != '*')
                {
                    dp[sl, pl] = IsMatch(sl-1, pl-1) && dp[sl-1, pl-1] ;
                }
                else
                {
                    dp[sl, pl] = dp[sl, pl-2] || (IsMatch(sl-1, pl-2) && dp[sl-1, pl]);
                }
            }
        }
        return dp[s.Length, p.Length];
    }

    static void Main(string[] args)
    {
        // Console.WriteLine(IsMatch("abc", "abc"));
        // Console.WriteLine(IsMatch("abc", "ab."));
        // Console.WriteLine(IsMatch("abcc", "abc*"));
        // Console.WriteLine(IsMatch("ab", "abc*"));
        // Console.WriteLine(IsMatch("ab", "abc*d"));
        Console.WriteLine(IsMatch("mississippi", "mis*is*p*."));
        Console.WriteLine(IsMatch("aab", "c*a*b"));
        Console.WriteLine(IsMatch("aa", "a"));
        Console.WriteLine(IsMatch("aaa", "ab*a*c*a"));
        Console.WriteLine(IsMatch("a", ".*..a*"));
    }
}

