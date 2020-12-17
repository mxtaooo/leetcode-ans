using System;
using System.Collections.Generic;

namespace CSharpConsoleApp
{

    static class Helper
    {
        public static List<int> AllIndexOf(this string s, string value)
        {
            var result = new List<int>();
            var slen = s.Length;
            var vlen = value.Length;

            List<int> InnerFunc(List<int> result, int start)
            {
                var index = s.IndexOf(value, start);
                if (index != -1)
                {
                    result.Add(index);
                    if (index + vlen < slen)
                    {
                        return InnerFunc(result, start + vlen);
                    }
                }
                return result;
            }
            return InnerFunc(result, 0);
        }

        public static Dictionary<int, List<int>> Copy(this Dictionary<int, List<int>> dict)
        {
            var result = new Dictionary<int, List<int>>(dict.Count);
            foreach (var (k, v) in dict)
            {
                result[k] = new List<int>(v);
            }
            return result;
        }

    }

    class Program
    {

        static List<int> FindSubstring(string s, string[] words)
        {
            // (id, len, indexes)
            var list = new List<(int, int, List<int>)>(words.Length);
            for (int i = 0; i < words.Length; i++)
            {
                var indexes = s.AllIndexOf(words[i]);
                if (indexes.Count == 0)
                {
                    return new List<int>();
                }
                list.Add((i, words[i].Length, indexes));
            }


        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
