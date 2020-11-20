class Solution
{
    // 子串逐一比较法
    static int StrStr(string haystack, string needle)
    {
        if (String.IsNullOrEmpty(needle)) return 0;

        for (int i = 0; i < haystack.Length - needle.Length + 1; i++)
        {
            if (haystack.Substring(i, needle.Length) == needle) return i;
        }
        return -1;
    }

    // 字串逐一比较法 - 小优化、不再频繁创建字符串对象；对于失败对比可立即停止
    static int StrStr(string haystack, string needle)
    {
        if (String.IsNullOrEmpty(needle)) return 0;

        for (int i = 0; i <= haystack.Length - needle.Length; i++)
        {
            var matched = true;
            for (int j = 0; j < needle.Length; j++)
            {
                if (haystack[i+j] != needle[j]) 
                {
                    matched = false;
                    break;
                }
            }
            if (matched) return i;
        }
        return -1;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(StrStr("hello", "o"));
    }
}