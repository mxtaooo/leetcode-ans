
class Solution
{
    public static void Main(string[] args)
    {
        var solution = new Solution();
        //Console.WriteLine($"{solution.}");
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

        Console.WriteLine($"{solution.IsMatch("abbabaaabbabbaababbabbbbbabbbabbbabaaaaababababbbabababaabbababaabbbbbbaaaabababbbaabbbbaabbbbababababbaabbaababaabbbababababbbbaaabbbbbabaaaabbababbbbaababaabbababbbbbababbbabaaaaaaaabbbbbaabaaababaaaabb", "**aa*****ba*a*bb**aa*ab****a*aaaaaa***a*aaaa**bbabb*b*b**aaaaaaaaa*a********ba*bbb***a*ba*bb*bb**a*b*bb")}");
        Console.WriteLine($"{solution.IsMatch("bbbababbbbabbbbababbaaabbaababbbaabbbaaaabbbaaaabb", "*b********bb*b*bbbbb*ba")}");
        Console.WriteLine($"{solution.IsMatch("aa", "a")}");
        Console.WriteLine($"{solution.IsMatch("cd", "?a")}");
    }

    public bool IsMatch(string s, string p)
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

}