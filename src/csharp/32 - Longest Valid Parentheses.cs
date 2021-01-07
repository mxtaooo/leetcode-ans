using System;

namespace CSharpConsoleApp
{
    class Program
    {
        static int LongestValidParentheses(string s)
        {
            var max = 0;
            var current = 0;
            var left = 0;
            foreach (var c in s)
            {
                switch (c)
                {
                    case '(':
                        left++;
                        break;
                    case ')':
                        if (left > 0)
                        {
                            left--;
                            // 存在问题、不应无条件延长本current
                            current += 2;
                        }
                        else
                        {
                            max = max > current ? max : current;
                            current = 0;
                        }
                        break;
                    default:
                        break;
                }
            }

            return max > current ? max : current;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{LongestValidParentheses("(()")}");
            Console.WriteLine($"{LongestValidParentheses(")()())")}");
            Console.WriteLine($"{LongestValidParentheses("")}");
            Console.WriteLine($"{LongestValidParentheses("()(()")}"); // error !
        }
    }
}
