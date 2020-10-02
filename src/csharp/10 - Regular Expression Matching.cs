class Solution
{
    static bool IsMatchOnSpan(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
    {
        if (p.IsEmpty) return s.IsEmpty;

        // 验证两者是否有相同的首字符
        var first = (!s.IsEmpty && (p[0] == s[0] || p[0] == '.'));
        if (p.Length >= 2 && p[1] == '*')
        {
            // 对于
            return IsMatchOnSpan(s, p.Slice(2)) || (first && IsMatchOnSpan(s.Slice(1), p));
        }
        else
        {
            return first && IsMatchOnSpan(s.Slice(1), p.Slice(1));
        }
    }
    public static bool IsMatch(string s, string p)
    {

        return IsMatchOnSpan(s.AsSpan(), p.AsSpan());
    }
    static void Main(string[] args)
    {
        Console.WriteLine(IsMatch("abc", "a*bc"));
    }
}

using System;

namespace CSharpSolution
{
    class Solution
    {
        static bool IsMatch(string s, string p)
        {
            bool IsMatch(int si, int pi) => si >= 0 && (p[pi] == '.' || s[si] == p[pi]);

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
}

