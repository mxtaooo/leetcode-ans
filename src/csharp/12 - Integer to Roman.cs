class Solution
{
    static string IntToRoman(int num)
    {
        var sb = new System.Text.StringBuilder();
        while (num > 0)
        {
            switch (num)
            {
                case var _ when num >= 1000:
                    sb.Append('M', num / 1000);
                    num %= 1000;
                    break;
                case var _ when num >= 900:
                    sb.Append("CM");
                    num -= 900;
                    break;
                case var _ when num >= 500:
                    sb.Append('D');
                    num -= 500;
                    break;
                case var _ when num >= 400:
                    sb.Append("CD");
                    num -= 400;
                    break;
                case var _ when num >= 100:
                    sb.Append('C', num / 100);
                    num %= 100;
                    break;
                case var _ when num >= 90:
                    sb.Append("XC");
                    num -= 90;
                    break;
                case var _ when num >= 50:
                    sb.Append('L');
                    num -= 50;
                    break;
                case var _ when num >= 40:
                    sb.Append("XL");
                    num -= 40;
                    break;
                case var _ when num >= 10:
                    sb.Append('X', num / 10);
                    num %= 10;
                    break;
                case var _ when num >= 9:
                    sb.Append("IX");
                    num -= 9;
                    break;
                case var _ when num >= 5:
                    sb.Append('V');
                    num -= 5;
                    break;
                case var _ when num >= 4:
                    sb.Append("IV");
                    num -= 4;
                    break;
                default:
                // case var _ when num >= 1:
                    sb.Append('I', num);
                    num = 0;
                    break;
            }
        }
        return sb.ToString();
    }
    static void Main(string[] args)
    {
        Console.WriteLine($"1 = {IntToRoman(1)}");
        Console.WriteLine($"3 = {IntToRoman(3)}");
        Console.WriteLine($"4 = {IntToRoman(4)}");
        Console.WriteLine($"9 = {IntToRoman(9)}");
        Console.WriteLine($"58 = {IntToRoman(58)}");
        Console.WriteLine($"1994 = {IntToRoman(1994)}");
        Console.WriteLine($"3999 = {IntToRoman(3999)}");
    }
}