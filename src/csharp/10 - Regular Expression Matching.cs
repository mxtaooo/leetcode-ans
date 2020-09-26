class Solution
{
    public static bool IsMatch(string s, string p)
    {
        static bool IsMatchSimple(ReadOnlySpan<char> s, ReadOnlySpan<char> p)
        {
            if (s.IsEmpty && p.IsEmpty) return true;
            return s[0] == p[0] && IsMatchSimple(s.Slice(1), p.Slice(1));
        }
        return IsMatchSimple(s.AsSpan(), p.AsSpan());
    }
    static void Main(string[] args)
    {
        Console.WriteLine(IsMatch("abc", "abc"));
    }
}