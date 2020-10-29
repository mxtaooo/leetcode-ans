class Solution
{
    static bool IsValid(string s)
    {
        var stack = new Stack<char>();
        foreach (var c in s)
        {
            switch (c)
            {
                case '(':
                case '{':
                case '[':
                    stack.Push(c);
                    break;
                case ')':
                    if (!(stack.TryPop(out var c0) && c0 == '(')) return false;
                    break;
                case '}':
                    if (!(stack.TryPop(out var c1) && c1 == '{')) return false;
                    break;
                case ']':
                    if (!(stack.TryPop(out var c2) && c2 == '[')) return false;
                    break;
                default:
                    break;
            }
        }
        return stack.Count == 0;
    }

    static void Main(string[] args)
    {
        Console.WriteLine(IsValid("()"));
        Console.WriteLine(IsValid("()[]{}"));
        Console.WriteLine(IsValid("([])"));
        Console.WriteLine(IsValid("(]"));
        Console.WriteLine(IsValid("([)]"));
        Console.WriteLine(IsValid("]"));
        Console.WriteLine(IsValid("()]"));
    }
}