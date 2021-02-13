using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpConsoleApp
{
    class Program
    {
        static string CountAndSay(int n)
        {
            var str = "1";
            for (int i = 1; i < n; i++)
            {
                var sb = new StringBuilder();
                var (@char, count) = (str[0], 0);
                foreach (var c in str)
                {
                    if (c == @char)
                    {
                        count++;
                    }
                    else
                    {
                        sb.Append(count).Append(@char);
                        (@char, count) = (c, 1);
                    }
                }
                str = sb.Append(count).Append(@char).ToString();
            }
            return str;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"1: {CountAndSay(1)}");
            Console.WriteLine($"2: {CountAndSay(2)}");
            Console.WriteLine($"3: {CountAndSay(3)}");
            Console.WriteLine($"4: {CountAndSay(4)}");
            Console.WriteLine($"5: {CountAndSay(5)}");
            Console.WriteLine($"6: {CountAndSay(6)}");
            Console.WriteLine($"7: {CountAndSay(7)}");
            Console.WriteLine($"8: {CountAndSay(8)}");
            Console.WriteLine($"9: {CountAndSay(9)}");
            Console.WriteLine($"10: {CountAndSay(10)}");
        }
    }
}
