
namespace ConsoleApp;

class Solution
{
    public static void Main(string[] args)
    {
        Console.WriteLine($"{IsInterleave("aabcc", "dbbca", "aadbbcbcac")}");
        Console.WriteLine($"{IsInterleave("aabcc", "dbbca", "aadbbbaccc")}");
        Console.WriteLine($"{IsInterleave("", "", "")}");
    }

    public static bool IsInterleave(string s1, string s2, string s3)
    {
        // 若是存在空字符串，直接比较另两个字符串即可
        if (string.IsNullOrEmpty(s1))
        {
            return s2 == s3;
        }
        if (string.IsNullOrEmpty(s2))
        {
            return s1 == s3;
        }

        // 若前两者字符串之和与第三个字符串不一致，构造必定失败
        if (s1.Length + s2.Length != s3.Length)
        {
            return false;
        }

        // 若第一个字符都不一致，构造必定失败
        if (s1[0] != s3[0] && s2[0] != s3[0])
        {
            return false;
        }

        var dp = new bool[s1.Length + 1, s2.Length + 1];
        dp[0, 0] = true;

        for (int l1 = 0; l1 <= s1.Length; l1++)
        {
            for (int l2 = 0; l2 <= s2.Length; l2++)
            {
                if ((l1 > 0 && dp[l1 - 1, l2] && s1[l1-1] == s3[l1 + l2 - 1])
                    || (l2 > 0 && dp[l1, l2 - 1] && s2[l2 - 1] == s3[l1 + l2 - 1]))
                {
                    dp[l1, l2] = true;
                }
            }
        }

        return dp[s1.Length, s2.Length];
    }

}
