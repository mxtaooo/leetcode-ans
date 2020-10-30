class Solution
{
    static List<string> GenerateParenthesis(int n)
    {
        static (string, string) SplitString(string str, int index)
        {
            return (str.Substring(0, index), str.Substring(index));
        }

        var result = new HashSet<string>() {"()"};
        for (int i = 2; i <= n; i++)
        {
            var set = new HashSet<string>();
            foreach (var partial in result)
            {
                for (int j = 0; j < partial.Length; j++)
                {
                    var (prefix, surfix) = SplitString(partial, j);
                    set.Add(prefix + "()" + surfix);
                }
            }
            result = set;
        }

        return new List<string>(result);
    }

    static void Main(string[] args)
    {
        Console.WriteLine(String.Join(',', GenerateParenthesis(1)));
        Console.WriteLine(String.Join(',', GenerateParenthesis(2)));
        Console.WriteLine(String.Join(',', GenerateParenthesis(3)));
    }
}