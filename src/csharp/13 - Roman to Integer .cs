class Solution
{
    static int RomanToInt(string s)
    {
        var value = 0;
        var span = s.AsSpan();
        while (!span.IsEmpty)
        {
            switch (s)
            {
                case var _ when span.StartsWith("CM"):
                    value += 900;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("CD"):
                    value += 400;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("XC"):
                    value += 90;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("XL"):
                    value += 40;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("IX"):
                    value += 9;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("IV"):
                    value += 4;
                    span = span.Slice(2);
                    break;
                case var _ when span.StartsWith("M"):
                    value += 1000;
                    span = span.Slice(1);
                    break;
                case var _ when span.StartsWith("D"):
                    value += 500;
                    span = span.Slice(1);
                    break;
                case var _ when span.StartsWith("C"):
                    value += 100;
                    span = span.Slice(1);
                    break;
                case var _ when span.StartsWith("L"):
                    value += 50;
                    span = span.Slice(1);
                    break;
                case var _ when span.StartsWith("X"):
                    value += 10;
                    span = span.Slice(1);
                    break;
                case var _ when span.StartsWith("V"):
                    value += 5;
                    span = span.Slice(1);
                    break;
                // case var _ when span.StartsWith("I"):
                default:
                    value += 1;
                    span = span.Slice(1);
                    break;
            }
        }
        return value;
    }
    
    static void Main(string[] args)
    {
        Console.WriteLine($"III = {RomanToInt("III")}");
        Console.WriteLine($"IV = {RomanToInt("IV")}");
        Console.WriteLine($"IX = {RomanToInt("IX")}");
        Console.WriteLine($"LVIII = {RomanToInt("LVIII")}");
        Console.WriteLine($"MCMXCIV = {RomanToInt("MCMXCIV")}");
    }
}