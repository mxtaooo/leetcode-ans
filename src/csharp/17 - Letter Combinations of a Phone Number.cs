class Solution
{
    static Dictionary<char, char[]> dict = new Dictionary<char, char[]>() 
    {
        {'2', new char[] {'a', 'b', 'c'}},
        {'3', new char[] {'d', 'e', 'f'}},
        {'4', new char[] {'g', 'h', 'i'}},
        {'5', new char[] {'j', 'k', 'l'}},
        {'6', new char[] {'m', 'n', 'o'}},
        {'7', new char[] {'p', 'q', 'r', 's'}},
        {'8', new char[] {'t', 'u', 'v'}},
        {'9', new char[] {'w', 'x', 'y', 'z'}}
    };
    static List<string> Append(List<string> list, char[] chars)
    {
        var result = new List<string>(list.Count * chars.Length);
        foreach (var item in list)
        {
            foreach (var c in chars)
            {
                result.Add(item + c);
            }
        }
        return result;
    }
    static List<string> LetterCombinations(string digits)
    {
        if (String.IsNullOrEmpty(digits)) 
        {
            return new List<string>();
        }
        var list = new List<string>() {String.Empty};
        foreach (var c in digits)
        {
            list = Append(list, dict[c]);
        }
        return list;
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"[{String.Join(',', LetterCombinations(""))}]");
        Console.WriteLine($"[{String.Join(',', LetterCombinations("2"))}]");
        Console.WriteLine($"[{String.Join(',', LetterCombinations("23"))}]");
    }
}