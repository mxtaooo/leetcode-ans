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