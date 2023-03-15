
class Solution
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        Console.WriteLine($"####################[MATCHED]####################");
        Console.WriteLine($"{solution.IsMatch("aa", "a?")}");
        Console.WriteLine($"{solution.IsMatch("aa", "a*")}");
        Console.WriteLine($"{solution.IsMatch("aa", "*")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "abcde")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "ab*e")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "ab*de")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "ab*cde")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "ab*?e")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "*?e")}");
        Console.WriteLine($"{solution.IsMatch("abcde", "*?")}");

        Console.WriteLine($"####################[UNMATCHED]####################");
        Console.WriteLine($"{solution.IsMatch("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb", "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb")}");
        Console.WriteLine($"{solution.IsMatch("bbbababbbbabbbbababbaaabbaababbbaabbbaaaabbbaaaabb", "*b********bb*b*bbbbb*ba")}");
        Console.WriteLine($"{solution.IsMatch("aa", "a")}");
        Console.WriteLine($"{solution.IsMatch("cd", "?a")}");
    }

    public bool IsMatch(string s, string p)
    {
        return Impl2(s, p);
    }

    public bool Impl1(string s, string p)
    {
        bool Match(int i, int j)
        {
            // at the end of s and p
            if (i == s.Length && j == p.Length)
            {
                return true;
            }

            // at the end of s, ensure other p is '*'
            if (i == s.Length)
            {
                while (j < p.Length)
                {
                    if (p[j] == '*')
                    {
                        j++;
                    }
                    else
                    {
                        return false;
                    }
                }
                return true;
            }

            // at the end of p, just return false
            if (j == p.Length)
            {
                return false;
            }

            // not the end of s and p
            switch (p[j])
            {
                case '?':
                    return Match(i + 1, j + 1);
                case '*':
                    // move j
                    for (; j < p.Length && p[j] == '*'; j++) { }

                    for (int k = i; k <= s.Length; k++)
                    {
                        if (Match(k, j))
                        {
                            return true;
                        }
                    }
                    return false;
                default:
                    return s[i] == p[j] && Match(i + 1, j + 1);
            }
        }
        return Match(0, 0);
    }

    public bool Impl2(string s, string p)
    {
        // if pattern is all star, match success.
        var isAllStar = true;
        for (int i = 0; i < p.Length; i++)
        {
            if (p[i] != '*')
            {
                isAllStar = false;
                break;
            }
        }
        if (isAllStar)
        {
            return true;
        }

        // empty string and empty pattern, match success.
        if (s.Length == 0 && p.Length == 0)
        {
            return true;
        }

        // the index of s
        var index = 0;
        
        for (int i = 0; i < p.Length; i++)
        {
            var sp = i;
            // empty pattern, just sliding...
            if (p[i] == '*' && sp == i)
            {
                continue;
            }
            // sliding, locate sub pattern
            for(; i < p.Length && p[i] != '*'; i++) { }
            // length of sub pattern
            var len = i - sp;

            // locate sub pattern in sub string
            var pos = IndexOf(s.AsSpan(index), p.AsSpan(sp, len));
            if (pos == -1)
            {
                return false;
            }

            index += pos + len;
        }

        return index == s.Length || (p.Length > 0 && p[^1] == '*');
    }

    public int IndexOf(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
    {
        for (int i = 0; i < s.Length; i++)
        {
            // s shorter than p, unmatch
            if (s.Length - i < p.Length)
            {
                return -1;
            }

            // s longer than p, compare one by one
            var matched = true;
            for (int j = 0; j < p.Length; j++) 
            {
                if (s[i+j] != p[j] && p[j] != '?')
                {
                    matched = false;
                    break;
                }
            }
            if (matched)
            {
                return i;
            }
        }
        return -1;
    }
}