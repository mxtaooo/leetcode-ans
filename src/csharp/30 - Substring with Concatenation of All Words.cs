using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpConsoleApp
{
    static class Helper
    {
        public static List<int> AllIndexOf(this string s, string value)
        {
            // 迭代器方式生成位置序列
            IEnumerable<int> InnerFunc0()
            {
                for (int i = s.IndexOf(value); i != -1; i = s.IndexOf(value, i+1))
                {
                    yield return i;
                }
            }

            // 尾递归方式将位置加入结果集中
            List<int> InnerFunc1(List<int> result, int start)
            {
                var index = s.IndexOf(value, start);
                if (index != -1)
                {
                    result.Add(index);
                    return InnerFunc(result, index + 1);
                }
                return result;
            }

            // return InnerFunc1(new List<int>(), 0);
            return new List<int>(InnerFunc0());
        }

        public static bool IsEmpty<TKey, TValue>(this Dictionary<TKey, TValue> dict) where TKey : notnull
            => dict.Count == 0;

        public static bool IsEmpty<T>(this ICollection<T> collection) => collection.Count == 0;

        public static string Format(this List<int> list)
        {
            if (list.IsEmpty())
            {
                return "[ ]";
            }
            return "[ " + list.Select(i => i.ToString()).Aggregate((s1, s2) => s1 + ", " + s2) + " ]";
        }
    }

    class Program
    {
        static bool IsExist(int index, Dictionary<string, int> count, Dictionary<string, HashSet<int>> dict)
        {
            if (count.IsEmpty())
            {
                return true;
            }
            foreach (var (word, indexes) in dict)
            {
                if (indexes.Contains(index) && count.ContainsKey(word))
                {
                    if (count[word] == 1)
                    {
                        count.Remove(word);
                    }
                    else
                    {
                        count[word] = count[word] - 1;
                    }
                    return IsExist(index + word.Length, count, dict);
                }
            }
            return false;
        }

        static List<int> FindSubstring(string s, string[] words)
        {
            var len = 0;
            var count = new Dictionary<string, int>();
            foreach (var word in words)
            {
                len += word.Length;
                count[word] = count.ContainsKey(word) ? (count[word] + 1) : 1;
            }

            var dict = new Dictionary<string, HashSet<int>>();
            foreach (var word in count.Keys)
            {
                dict[word] = new HashSet<int>(s.AllIndexOf(word));
                if (dict[word].IsEmpty())
                {
                    return new List<int>();
                }
            }

            var result = new List<int>();
            for (int i = 0; i < s.Length - len + 1; i++)
            {
                if (IsExist(i, new Dictionary<string, int>(count), dict))
                {
                    result.Add(i);
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(FindSubstring("barfoothefoobarman", new string[] { "foo", "bar" }).Format());
            Console.WriteLine(FindSubstring("wordgoodgoodgoodbestword", new string[] { "word", "good", "best", "word" }).Format());
            Console.WriteLine(FindSubstring("barfoofoobarthefoobarman", new string[] { "bar", "foo", "the" }).Format());
            Console.WriteLine(FindSubstring("acaaa", new string[] { "aa", "ca" }).Format());
        }
    }
}
