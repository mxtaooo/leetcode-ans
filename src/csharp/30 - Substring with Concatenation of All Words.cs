using System;
using System.Collections.Generic;
using System.Linq;


namespace CSharpConsole
{

    class Solution
    {
        static List<int> AllIndexOf(string s, string value)
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

        static Dictionary<int, List<int>> Copy(Dictionary<int, List<int>> dict)
        {
            var result = new Dictionary<int, List<int>>(dict.Count);
            foreach (var (k, v) in dict)
            {
                result[k] = new List<int>(v);
            }
            return result;
        }

        static List<int> FindSubstring(string s, string[] words)
        {

            // (id, len, indexes)
            var list = new List<(int, int, List<int>)>(words.Length);
            for (int i = 0; i < words.Length; i++)
            {
                var indexes = AllIndexOf(s, words[i]);
                if (indexes.Count == 0)
                {
                    return new List<int>();
                }
                list.Add((i, words[i].Length, indexes));
            }

            // index in s -> word
            // var dict = new Dictionary<int, List<int>>();
            // var len = 0;
            // for (int i = 0; i < words.Length; i++)
            // {
            //     len += words[i].Length;
            //     var indexes = AllIndexOf(s, words[i]);
            //     if (indexes.Count == 0)
            //     {
            //         return new List<int>();
            //     }
            //     foreach (var index in indexes)
            //     {
            //         if (dict.TryGetValue(index, out var value))
            //         {
            //             value.Add(i);
            //         }
            //         else
            //         {
            //             dict[index] = new List<int> { i };
            //         }
            //     }
            // }

            // var result = new List<int>();
            // for (int i = 0; i < s.Length - len + 1; i++)
            // {
            //     if (dict.ContainsKey(i)) 
            //     {

            //     }
            // }

        }

        static void Main(string[] args)
        {
            
        }
    }
}
