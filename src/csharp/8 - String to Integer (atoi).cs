class Solution
{
    public static int MyAtoi(string str)
    {
        var pos = 0;
        for (; pos < str.Length && char.IsWhiteSpace(str[pos]); pos++ ) { }
        if (pos == str.Length) return 0;
        if (str[pos] != '+' && str[pos] != '-' && !char.IsDigit(str[pos])) return 0;
        
        var result = 0;
        var flag = str[pos] == '-' ? -1 : 1;
        for (pos += char.IsDigit(str[pos]) ? 0 : 1; pos < str.Length && char.IsDigit(str[pos]); pos++)
        {
            var cur = flag * (str[pos] - '0');
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && cur > 7)) return int.MaxValue;
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && cur < -8)) return int.MinValue;
            result = result * 10 + cur;
        }
        
        return result;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(MyAtoi("42"));
        Console.WriteLine(MyAtoi("       -123"));
        Console.WriteLine(MyAtoi("4193 with words"));
        Console.WriteLine(MyAtoi("words and 987"));
        Console.WriteLine(MyAtoi("-91283472332"));
    }
}