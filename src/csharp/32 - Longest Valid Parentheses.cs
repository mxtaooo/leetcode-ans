using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    class Program
    {
        #region Error Solution
        //static int LongestValidParentheses(string s)
        //{
        //    var max = 0;
        //    var current = 0;
        //    var left = 0;
        //    foreach (var c in s)
        //    {
        //        switch (c)
        //        {
        //            case '(':
        //                left++;
        //                break;
        //            case ')':
        //                if (left > 0)
        //                {
        //                    left--;
        //                    current += 2;
        //                }
        //                else
        //                {
        //                    max = max > current ? max : current;
        //                    current = 0;
        //                }
        //                break;
        //            default:
        //                break;
        //        }
        //    }
        //    return max > current ? max : current;
        //}
        #endregion

        #region Brute Force Solution
        //static int LongestValidParentheses(string s)
        //{
        //    bool IsValid(int start, int length)
        //    {
        //        var stack = 0;
        //        for (int i = 0; i < length; i++)
        //        {
        //            if (s[start + i] == '(')
        //            {
        //                stack++;
        //            }
        //            else
        //            {
        //                if (stack > 0)
        //                {
        //                    stack--;
        //                }
        //                else
        //                {
        //                    return false;
        //                }
        //            }
        //        }
        //        return stack == 0;
        //    }

        //    //// 从0 -> 2 -> 4 逐渐尝试
        //    //var max = 0;
        //    //for (int len = 2; len <= s.Length; len += 2)
        //    //{
        //    //    for (int i = 0; i <= s.Length - len; i++)
        //    //    {
        //    //        if (IsValid(i, len))
        //    //        {
        //    //            max = len;
        //    //            break;
        //    //        }
        //    //    }
        //    //}
        //    //return max;

        //    // 从max -> ... -> 4 -> 2 -> 0 逐渐尝试
        //    for (int len = s.Length % 2 == 0 ? s.Length : s.Length - 1; len >= 0; len -= 2)
        //    {
        //        for (int i = 0; i <= s.Length - len; i++)
        //        {
        //            if (IsValid(i, len))
        //            {
        //                return len;
        //            }
        //        }
        //    }
        //    return 0;
        //}
        #endregion

        #region Dynamic Programming Solution
        //static int LongestValidParentheses(string s)
        //{
        //    var dp = new int[s.Length];
        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        if (s[i] == ')')
        //        {
        //            if (s[i-1] == '(')
        //            {
        //                dp[i] = (i >= 2 ? dp[i - 2]　: 0) + 2;
        //            }
        //            else if (i - dp[i - 1] >= 1 && s[i - dp[i - 1] - 1] == '(')
        //            {
        //                dp[i] = (i - dp[i - 1] >= 2 ? dp[i - dp[i - 1] - 2] : 0) + dp[i - 1] + 2;
        //            }
        //        }
        //    }
        //    return dp.Length == 0 ? 0 : dp.Max();
        //}
        #endregion

        #region Stack
        //static int LongestValidParentheses(string s)
        //{
        //    var max = 0;
        //    var stack = new Stack<int>();
        //    stack.Push(-1);
        //    for (int i = 0; i < s.Length; i++)
        //    {
        //        if (s[i] == '(')
        //        {
        //            stack.Push(i);
        //        }
        //        else
        //        {
        //            stack.Pop();
        //            if (stack.Count != 0)
        //            {
        //                max = Math.Max(max, i - stack.Peek());
        //            }
        //            else
        //            {
        //                stack.Push(i);
        //            }
        //        }
        //    }
        //    return max;
        //}
        #endregion

        #region 2 Directions Scan
        static int LongestValidParentheses(string s)
        {
            var max = 0;
            var (left, right) = (0, 0);
            for (int i = 0; i < s.Length; i++)
            {
                left += s[i] == '(' ? 1 : 0;
                right += s[i] == ')' ? 1 : 0;
                max = Math.Max(max, left == right ? left + right : 0);
                (left, right) = left >= right ? (left, right) : (0, 0);
            }
            (left, right) = (0, 0);
            for (int i = s.Length - 1; i >= 0; i--)
            {
                left += s[i] == '(' ? 1 : 0;
                right += s[i] == ')' ? 1 : 0;
                max = Math.Max(max, left == right ? left + right : 0);
                (left, right) = left <= right ? (left, right) : (0, 0);
            }
            return max;
        }
        #endregion

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{LongestValidParentheses("(()")}");
            Console.WriteLine($"{LongestValidParentheses(")()())")}");
            Console.WriteLine($"{LongestValidParentheses("")}");
            Console.WriteLine($"{LongestValidParentheses("()(()")}"); // error !
            Console.WriteLine($"{LongestValidParentheses(")(((((()())()()))()(()))(")}"); // error !
            Console.WriteLine($"{LongestValidParentheses("(()()")}");
        }
    }
}
